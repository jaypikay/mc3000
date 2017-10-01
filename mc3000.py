#! /usr/bin/env python3
# -*- coding: utf-8 -*-
# vim:fenc=utf-8:ts=8:et:sw=4:sts=4
#
# Copyright © 2017 jpk <jpk@thor>
#
# Distributed under terms of the MIT license.

"""
ret returns data:

offset 00h defines packet type:

 * 5Ah: Get System Data
 * 5Fh: Get Charge Data

# Machine SN
# num1 = 0
# str1 = ''
# for i in range(16):
#     if i < 15:
#         num1 += ret[17 + i]
#     str2 = '{:02X}'.format(num1)
#     str1 += str2
# print(str1)

s:{c}^{n}'.format(s='str', n=5, c='x')

# 7 -> 2: Dummy, 1: Simple, 0 Advanced
# 8 -> 1: Farenheit, 0: Celcius
# 9 -> 16: silent ... 1: loud, 0: off
# 16:22 --> core_type expects 100083
# core_type = bytes(ret[16:22]).decode('utf-8')
# 22 -> upgrade type
# 23 -> encrypted
# 24:25: -> customer id: [25] * 256 + [26]
#customer_id = ret[24] * 256 + ret[25]
#print(customer_id)
# 26 -> language
#language_id = ret[26]
#print(language_id)
# 28:29 -> sovware version
#print(ret[27] * 1.0 + ret[28] * 1.0 / 100.0)
# 30 -> HW Version
#print(ret[29])
# 31 -> reserved
# 32 -> checksum
#print(ret[31])
"""


import usb.core
import usb.util
from hexdump import *
from collections import namedtuple
from struct import pack


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
        # check if device is already claimed and free it
        for config in self.device:
            for config_index in range(config.bNumInterfaces):
                if self.device.is_kernel_driver_active(config_index):
                    self.device.detach_kernel_driver(config_index)
        self.device.set_configuration()
        self.config = self.device.get_active_configuration()
        self.interface = self.config[(0, 0)]
        usb.util.claim_interface(self.device, self.interface)

        self.ep_in = self.device[0][(0, 0)][0]
        self.ep_out = self.device[0][(0, 0)][1]

        self.machine_info = self.get_machine_info()
        self.battery_data = self.get_battery_data()

    def get_machine_info(self):
        packet = b'\x0f\x04\x5a\x00\x04\x5e\xff\xff'
        self.send_raw(packet)
        response = self.read()

        core_type = response[16:22].decode('utf-8')
        upgrade_type = response[22]
        is_encrypted = response[23] == b'\x01'
        customer_id = response[24] * 256 + response[25]
        language_id = response[26]
        software_version = '{:.2f}'.format(response[27] * 1.0 + response[28] * 1.0 / 100.0)
        hardware_version = response[29]
        reserved = response[30]
        checksum = response[31]
        # hardcoded for now

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
            print('[ ] Read charger data slot #{}'.format(slot + 1))
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

    def get_charging_progress(self):
        batteries = []
        for slot in range(4):
            print('[ ] Read progress data slot #{}'.format(slot + 1))
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


def encryption(buffer):
    num = 0
    while num < 59392:
        for index in range(64):
            buffer[num + index] ^= buffer[num + index + 64]
        num += 128


if __name__ == '__main__':
    print('[ ] Initializing USB Connection')
    mc3000 = MC3000()
    print(mc3000.get_machine_info())

    # minimal packet for get_system_data
    #print('[ ] Get System Data')
    #packet = b'\x0f\x04\x5a\x00\x04\x5e\xff\xff'
    #hexdump(packet)
    #mc3000.send_raw(packet)
    #response = mc3000.read()
    #hexdump(response)

    batteries = mc3000.get_battery_data()
    for battery in batteries:
        print(battery)
    status = mc3000.get_charging_progress()
    for battery in status:
        print(battery)
