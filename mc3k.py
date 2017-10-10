#! /usr/bin/env python3
# -*- coding: utf-8 -*-
# vim:fenc=utf-8:ts=8:et:sw=4:sts=4
#
# Copyright © 2017 jpk <jpk@dwarf>
#
# Distributed under terms of the MIT license.

"""

"""

import sys
import time
from usb.core import USBError

from mc3000 import MC3000
from mc3000rrd import *


RPT_NAME = 'MC3000-{date}-Report.txt'
RRD_NAME = 'MC3000-{date}-Slot{index}.rrd'
PNG_NAME = 'MC3000-{date}-Slot{index}.png'


if __name__ == '__main__':
    mc3k = MC3000()

    print('Preparing RRDs for battery slots...')
    timestamp = int(time.time())

    rptfile = open(RPT_NAME.format(date=timestamp), 'w')

    for battery in mc3k.battery_data:
        print('  - Slot #{index}: {mode} {battery}'.format(index=battery.slot+1,
                                                           mode=battery.mode,
                                                           battery=battery.type))
        create_rrd(RRD_NAME.format(index=battery.slot+1, date=timestamp), timestamp)

    rptfile.write('Charger Report\n\nStart Time: {date}\nBatteries:\b'.format(date=timestamp))
    for battery in mc3k.get_charging_progress():
        if battery.voltage > 0:
            rptfile.write(' - Battery in Slot #{slot}\n'.format(slot=battery.slot+1))
            rptfile.write('   Voltage: {voltage}\n'.format(voltage=battery.voltage))
            rptfile.write('   Temperature: {bat_tem}\n'.format(bat_tem=battery.bat_tem))
    rptfile.write('\n')

    try:
        print('Starting charging progress...')
        mc3k.start()
        while True:
            ts = int(time.time())
            try:
                for battery in mc3k.get_charging_progress():
                    dataset = {
                        'ts': ts,
                        'voltage': battery.voltage,
                        'current': battery.current,
                        'bat_tem': battery.bat_tem
                    }
                    update_rrd(RRD_NAME.format(index=battery.slot+1, date=timestamp), dataset)
                time.sleep(1)
            except USBError:
                pass
    except KeyboardInterrupt:
        pass
    finally:
        print('Terminating...')
        mc3k.close()
    end_ts = int(time.time())

    rptfile.write('Charging summary for Batteries:\n')
    rptfile.write('End Time: {date}'.format(end_ts))
    for battery in mc3k.get_charging_progress():
        if battery.voltage > 0:
            rptfile.write(' - Battery in Slot #{slot}\n'.format(slot=battery.slot+1))
            rptfile.write('   Voltage: {voltage}\n'.format(voltage=battery.voltage))
            rptfile.write('   Time: {time}\n'.format(time=battery.work_time))
            rptfile.write('   Temperature: {bat_tem}\n'.format(bat_tem=battery.bat_tem))
            rptfile.write('   Inner resistance: {ir}\n'.format(ir=battery.inner_resistance))
    rptfile.close()

    print('Preparing graphs for battery slots...')
    for battery in mc3k.battery_data:
        print('  - Slot #{index}: Rendering graph...'.format(index=battery.slot+1))
        graph_rrd(PNG_NAME.format(index=battery.slot+1, date=timestamp),
                  RRD_NAME.format(index=battery.slot+1, date=timestamp),
                  timestamp, end_ts)
    print('Finished.')
