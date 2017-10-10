#! /usr/bin/env python
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
import usb

from mc3000 import MC3000
from mc3000rrd import *


RRD_NAME = 'MC3000-{date}-Slot{index}.rrd'
PNG_NAME = 'MC3000-{date}-Slot{index}.png'


if __name__ == '__main__':
    mc3k = MC3000()

    print('Preparing RRDs for battery slots...')
    timestamp = int(time.time())
    for i, battery in enumerate(mc3k.battery_data):
        print('  - Slot #{index}: {mode} {battery}'.format(index=i+1, mode=battery.mode,
                                                           battery=battery.type))
        create_rrd(RRD_NAME.format(index=i+1, date=timestamp),
                   timestamp)

    try:
        print('Recording charging progress...')
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
            except usb.core.USBError:
                pass
    except KeyboardInterrupt:
        pass
    finally:
        print('Terminating...')
        mc3k.close()

    print('Preparing graphs for battery slots...')
    ts = int(time.time())
    for i, battery in enumerate(mc3k.battery_data):
        print('  - Slot #{index}: Rendering graph...'.format(index=i+1))
        graph_rrd(PNG_NAME.format(index=i+1, date=timestamp),
                  RRD_NAME.format(index=i+1, date=timestamp),
                  timestamp, ts)
