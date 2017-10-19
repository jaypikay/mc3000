#! /usr/bin/env python3
# -*- coding: utf-8 -*-
# vim:fenc=utf-8:ts=8:et:sw=4:sts=4
#
# Copyright © 2017 jpk <jpk@goatpr0n.de>
#
# Distributed under terms of the MIT license.

"""
MC300 Charger Monitoring - CLI Tool
-----------------------------------

The monitoring tool will observe the charging progress until all batteries are charged.

During the monitoring progress, for each battery slot available a RRD file is created to record the
progress. The progress itself is summurized in a report file. After the monitoring progress, a PNG
file is rendered for each RRD file.
"""

import os
import time
from usb.core import USBError

from mc3000 import MC3000
from mc3000rrd import *


RPT_NAME = 'MC3000-{date}-Report.txt'
RRD_NAME = 'MC3000-{date}-Slot{index}.rrd'
PNG_NAME = 'MC3000-{date}-Slot{index}.png'

OUTPUT_DIR = './data/'


if __name__ == '__main__':
    mc3k = MC3000()
    occupied_slots = []

    print('Preparing RRDs for battery slots...')
    timestamp = int(time.time())

    rpt_filename = os.path.join(OUTPUT_DIR, RPT_NAME.format(date=timestamp))
    rptfile = open(rpt_filename, 'w')

    for battery in mc3k.battery_data:
        print('  - Slot #{index}: {mode} {battery}'.format(index=battery.slot+1,
                                                           mode=battery.mode,
                                                           battery=battery.type))
        rrd_filename = os.path.join(OUTPUT_DIR, RRD_NAME.format(index=battery.slot+1,
                                                                date=timestamp))
        create_rrd(rrd_filename, timestamp)

    rptfile.write('Charger Report\n\nStart Time: {date}\nBatteries:\n'.format(date=timestamp))
    for battery in mc3k.get_charging_progress():
        if battery.voltage > 0:
            rptfile.write(' - Battery in Slot #{slot}\n'.format(slot=battery.slot+1))
            rptfile.write('   Voltage: {voltage}\n'.format(voltage=battery.voltage))
            rptfile.write('   Temperature: {bat_tem}\n'.format(bat_tem=battery.bat_tem))
        else:
            rptfile.write(' - Battery in Slot #{slot} not occupied\n'.format(slot=battery.slot+1))
    rptfile.write('\n')

    try:
        print('Starting charging progress...')
        mc3k.start()
        time.sleep(1)
        # Can this be optimized?
        batteries = mc3k.get_charging_progress()
        while any(slot.work == 1 for slot in batteries):
            ts = int(time.time())
            try:
                for battery in batteries:
                    dataset = {
                        'ts': ts,
                        'voltage': battery.voltage,
                        'current': battery.current,
                        'bat_tem': battery.bat_tem
                    }
                    if battery.work == 1:
                        rrd_filename = os.path.join(OUTPUT_DIR, RRD_NAME.format(index=battery.slot+1,
                                                                                date=timestamp))
                        update_rrd(rrd_filename, dataset)
                time.sleep(1)
                batteries = mc3k.get_charging_progress()
            except USBError:
                pass
    except KeyboardInterrupt:
        pass
    finally:
        print('Terminating...')
        mc3k.close()
    end_ts = int(time.time())

    rptfile.write('Charging summary for Batteries:\n')
    rptfile.write('End Time: {date}'.format(date=end_ts))
    for battery in mc3k.get_charging_progress():
        if battery.voltage > 0:
            rptfile.write(' - Battery in Slot #{slot}\n'.format(slot=battery.slot+1))
            rptfile.write('   Voltage: {voltage}\n'.format(voltage=battery.voltage))
            rptfile.write('   Capacity: {caps}\n'.format(caps=battery.caps))
            rptfile.write('   Time: {time}\n'.format(time=battery.work_time))
            rptfile.write('   Temperature: {bat_tem}\n'.format(bat_tem=battery.bat_tem))
            rptfile.write('   Inner resistance: {ir}\n'.format(ir=battery.inner_resistance))
        else:
            rptfile.write(' - Battery in Slot #{slot} not occupied\n'.format(slot=battery.slot+1))
    rptfile.close()

    print('Preparing graphs for battery slots...')
    for battery in mc3k.battery_data:
        print('  - Slot #{index}: Rendering graph...'.format(index=battery.slot+1))
        rrd_filename = os.path.join(OUTPUT_DIR, RRD_NAME.format(index=battery.slot+1,
                                                                date=timestamp))
        png_filename = os.path.join(OUTPUT_DIR, PNG_NAME.format(index=battery.slot+1,
                                                                date=timestamp))
        graph_rrd(png_filename, rrd_filename, timestamp, end_ts)
    print('Finished.')
