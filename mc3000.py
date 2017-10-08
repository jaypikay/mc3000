#! /usr/bin/env python3
# -*- coding: utf-8 -*-
# vim:fenc=utf-8:ts=8:et:sw=4:sts=4
#
# Copyright © 2017 jpk <jpk@goatpr0n.de>
#
# Distributed under terms of the MIT license.

"""
"""

from struct import pack
from collections import namedtuple
from hexdump import hexdump
import usb.core
import usb.util


MachineInfo = namedtuple('machine_info',
                         ['core_type', 'upgrade_type', 'is_encrypted', 'customer_id',
                          'language_id', 'software_version', 'hardware_version', 'reserved',
                          'checksum', 'machine_id'])

ProgressInfo = namedtuple('charge_data',
                          ['slot', 'work', 'work_time', 'voltage', 'current', 'caps',
                           'caps_decimal', 'dcaps', 'bat_tem', 'inner_resistance', 'checksum'])

Battery = namedtuple('battery_data',
                     ['slot', 'work', 'type', 'mode', 'caps', 'cur', 'dCur', 'cut_volt',
                      'end_volt', 'end_cur', 'end_dcur', 'cycle_count', 'cycle_delay',
                      'cycle_mode', 'peak_sense', 'trickle', 'hold_volt', 'cut_temp', 'cut_time',
                      'tem_unit', 'checksum'])

BATTERY_TYPE = {
    0: 'LiIon',
    1: 'LiFe',
    2: 'LiHV',
    3: 'NiMH',
    4: 'NiCd',
    5: 'NiZn',
    6: 'Eneloop',
}
TEM_UNIT = ('°C', '°F')
WORK_PROGRESS = {
    1: 'Charging',
    4: 'Finished'
}

CMD_PACKET_HEADER = b'\x0f\x04'
CMD_PACKET_TAIL = b'\xff\xff'

CMD_READ_PROGRESS_DATA = b'\x55' # 85
CMD_READ_CHARGER_DATA = b'\x5f' # 95


class MC3000(object):

    def __init__(self):
        self.device = usb.core.find(idVendor=0x0000, idProduct=0x0001)
        if not self.device:
            raise Exception('Device not found')
        # check if device is already claimed and free it
        for config in self.device:
            for config_index in range(config.bNumInterfaces):
                if self.device.is_kernel_driver_active(config_index):
                    self.device.detach_kernel_driver(config_index)
        self.device.set_configuration()
        self.config = self.device.get_active_configuration()
        self.interface = self.config[(0, 0)]
        usb.util.claim_interface(self.device, self.interface)

        self.device.reset()

        self.ep_in = self.device[0][(0, 0)][0]
        self.ep_out = self.device[0][(0, 0)][1]

        self.machine_info = self.get_machine_info()
        self.battery_data = self.get_battery_data()

    def close(self):
        usb.util.dispose_resources(self.device)

    def get_machine_info(self):
        packet = b'\x0f\x04\x5a\x00\x04\x5e\xff\xff'
        self.send_raw(packet)
        response = self.read()
        # hexdump(response)

        try:
            core_type = response[16:22].decode('utf-8')
        except UnicodeDecodeError:
            core_type = response[16:22]
        upgrade_type = response[22]
        is_encrypted = response[23] == b'\x01'
        customer_id = response[24] * 256 + response[25]
        language_id = response[26]
        software_version = '{:.2f}'.format(response[27] * 1.0 + response[28] * 1.0 / 100.0)
        hardware_version = response[29]
        reserved = response[30]
        checksum = response[31]

        crc = 0
        machine_id = ''
        for j in range(16):
            if j < 15:
                crc += response[16 + j]
            text2 = '{:X}'.format(response[16 + j])
            machine_id += '{s:{c}>{n}}'.format(s=text2, n=2, c='0')

        # prevent crc to be negative by masking it
        crc = ~crc & 0xff
        crc += 1
        if not crc == checksum:
            raise Exception('Checksum error in device data packet')
        self.system_data = MachineInfo(core_type, upgrade_type, is_encrypted, customer_id,
                                       language_id, software_version, hardware_version, reserved,
                                       checksum, machine_id)
        return self.system_data

    def packet_checksum(self, data_packet):
        crc = 0
        for i in range(0, 63):
            crc += data_packet[i]
            crc &= 0xff
        return crc

    def get_battery_data(self):
        batteries = []
        for slot in range(4):
            self.send(CMD_READ_CHARGER_DATA, slot)
            response = self.read()
            if response[-1] != self.packet_checksum(response):
                continue

            slot = response[1]
            work = response[2]
            battery_type = BATTERY_TYPE[response[3]]
            mode = response[4]
            caps = response[5] << 8 | response[6]
            cur = response[9] << 8 | response[10]
            dcur = response[12] << 8 | response[13]
            cut_volt = response[15] << 8 | response[16]
            end_volt = response[18] << 8 | response[19]
            end_cur = response[21] << 8 | response[22]
            end_dcur = response[24] << 8 | response[25]
            cycle_count = response[26]
            cycle_delay = response[27]
            cycle_mode = response[28]
            peak_sense = response[28]
            trickle = response[30] * 10
            hold_volt = response[32] << 8 | response[33]
            cut_temp = response[35] * 10
            cut_time = response[37] << 8 | response[38]
            tem_unit = TEM_UNIT[response[40]]
            checksum = response[63]

            battery = Battery(slot, work, battery_type, mode, caps, cur, dcur, cut_volt, end_volt,
                              end_cur, end_dcur, cycle_count, cycle_delay, cycle_mode, peak_sense,
                              trickle, hold_volt, cut_temp, cut_time, tem_unit, checksum)
            batteries.append(battery)
        return batteries

    def get_charging_progress(self, battery_slot='all'):
        batteries = []

        # All slots
        if battery_slot == 'all':
            battery_slot = range(4)
        else:
            battery_slot = [battery_slot]

        for slot in battery_slot:
            self.send(CMD_READ_PROGRESS_DATA, slot)
            response = self.read()
            if response[-1] != self.packet_checksum(response):
                continue
            # hexdump(response)

            # unknown values
            # num3 = response[2]
            # num4 = response[3]
            # num5 = response[4]
            # print('num3  {}'.format(num3))
            # print('num4  {}'.format(num4))
            # print('num5  {}'.format(num5))
            # print('num6  {}'.format(num6))

            slot = response[1]
            work = response[5]
            num6 = 0
            if work >= 128:
                num6 = work - 128 + 1
            work_time = response[6] << 8 | response[7]
            voltage = response[8] << 8 | response[9]
            # why?
            if work_time > 0:
                work_time -= 1
            current = response[10] << 8 | response[11]
            caps = response[12] << 8 | response[13]
            caps_decimal = response[24]
            # purpose unknown
            if work == 2:
                dcaps = caps
            else:
                dcaps = None
            bat_tem = response[14] << 8 | response[15]
            bat_tem &= 0x7fff
            inner_resistance = response[16] << 8 | response[17]
            checksum = response[63]

            status = ProgressInfo(slot, work, work_time, voltage, current, caps, caps_decimal,
                                  dcaps, bat_tem, inner_resistance, checksum)
            batteries.append(status)
        return batteries

    def send_raw(self, buffer):
        return self.device.write(self.ep_out.bEndpointAddress, buffer)

    def send(self, cmd, buffer):
        if cmd == CMD_READ_CHARGER_DATA:
            slotcmd = (int.from_bytes(cmd, byteorder='little')) + buffer
            cmd_packet = pack('2scxbb2s', CMD_PACKET_HEADER, cmd, buffer, slotcmd, CMD_PACKET_TAIL)
            self.send_raw(cmd_packet)
        elif cmd == CMD_READ_PROGRESS_DATA:
            slotcmd = (int.from_bytes(cmd, byteorder='little')) + buffer
            cmd_packet = pack('2scxbb2s', CMD_PACKET_HEADER, cmd, buffer, slotcmd, CMD_PACKET_TAIL)
            self.send_raw(cmd_packet)

    def read(self, expected_length=64):
        return self.device.read(self.ep_in.bEndpointAddress, expected_length).tobytes()


if __name__ == '__main__':
    mc3000 = MC3000()
    print(mc3000.get_machine_info())

    batteries = mc3000.get_battery_data()
    for battery in batteries:
        print(battery)

    status = mc3000.get_charging_progress()
    for battery in status:
        print(battery)

    status = mc3000.get_charging_progress(battery_slot=2)
    for battery in status:
        print(battery)
