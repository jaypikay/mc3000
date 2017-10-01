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


system_data = namedtuple('machine_info',
                         ['core_type', 'upgrade_type', 'is_encrypted', 'customer_id',
                          'language_id', 'software_version', 'hardware_version', 'reserved',
                          'checksum', 'machine_id'])

charge_data = namedtuple('charge_data',
                         ['work', 'type', 'mode', 'cycle_count', 'cycle_delay', 'cycle_mode'])

battery_data = namedtuple('battery_data',
                          ['caps', 'cur', 'dCur', 'cut_volt', 'end_volt', 'end_cur', 'end_dcur',
                           'peak_sense', 'trickle', 'hold_volt', 'cut_temp', 'cur_temp',
                           'tem_unit'])

#                          ['work', 'mAh', 'time', 'voltage', 'current', 'temp_ext',
#                           'temp_int', 'impedance_int', 'cells'])

BATTERY_TYPE = {
    0: 'LiIon',
    1: 'LiFe',
    2: 'LiHV',
    3: 'NiMH',
    4: 'NiCd',
    5: 'NiZn',
    6: 'Eneloop',
}

CMD_PACKET_HEADER = b'\x0f\x04'
CMD_PACKET_TAIL = b'\xff\xff'

CMD_READ_CHARGER_DATA = b'\x5f'  # 95


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

        self.get_device_data()

    def get_device_data(self):
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
        self.system_data = system_data(core_type, upgrade_type, is_encrypted, customer_id,
                                       language_id, software_version, hardware_version,
                                       reserved, checksum, machine_id)
        return self.system_data

    def send_raw(self, buffer):
        return self.device.write(self.ep_out.bEndpointAddress, buffer)

    def send(self, cmd, buffer):
        if cmd == CMD_READ_CHARGER_DATA:
            slotcmd = (int.from_bytes(cmd, byteorder='little')) + buffer
            cmd_packet = pack('2scxbb2s', CMD_PACKET_HEADER, cmd, buffer, slotcmd, CMD_PACKET_TAIL)
            hexdump(cmd_packet)
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
    #packet = b'\x0f\x04\x5a\x00\x04\x5e\xff\xff\x00\x05\xdc\x01\xf4\x0b\xb8\x10\x68\x00\x96\x01\xf4\x01'
    #packet += b'\x00\x00\x00\x03\x00\x00\x2d\x00\xb4\x00\x00\x95\xff\xff\x00\x00\x00\x00\x00\x00\x00'
    #packet += b'\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00'
    #hexdump(packet)

    print('[ ] Initializing USB Connection')
    mc3000 = MC3000()
    print(mc3000.get_device_data())

    # minimal packet for get_system_data
    print('[ ] Get System Data')
    packet = b'\x0f\x04\x5a\x00\x04\x5e\xff\xff'
    hexdump(packet)
    mc3000.send_raw(packet)
    response = mc3000.read()
    hexdump(response)

    for slot in range(4):
        print('[ ] Read charger data slot #{}'.format(slot + 1))
        mc3000.send(CMD_READ_CHARGER_DATA, slot)
        response = mc3000.read()
        battery_type = BATTERY_TYPE[response[3]]
        print(battery_type)

    # print('[ ] Get ... Data')
    # packet = b'\x0f\x04\x5f\x00\x00\x5f\xff\xff'
    # hexdump(packet)
    # mc3000.send_raw(packet)
    # response = mc3000.read()
    # hexdump(response)

    # print('[ ] Get ... Data')
    # packet = b'\x0f\x04\x5f\x00\x01\x60\xff\xff'
    # hexdump(packet)
    # mc3000.send_raw(packet)
    # response = mc3000.read()
    # hexdump(response)

    # print('[ ] Get ... Data')
    # packet = b'\x0f\x04\x5f\x00\x02\x61\xff\xff'
    # hexdump(packet)
    # mc3000.send_raw(packet)
    # response = mc3000.read()
    # hexdump(response)

    # print('[ ] Get ... Data')
    # packet = b'\x0f\x04\x5f\x00\x03\x62\xff\xff'
    # hexdump(packet)
    # mc3000.send_raw(packet)
    # response = mc3000.read()
    # hexdump(response)

    # for cycle in range(10):
    #     print('[ ] #{}: Reading random output...'.format(cycle))
    #     try:
    #         response = mc3000.read()
    #         hexdump(response)
    #     except usb.core.USBError:
    #         print('[!] #{}: No data arrived on time'.format(cycle))
