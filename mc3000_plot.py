#! /usr/bin/env python3
# -*- coding: utf-8 -*-
# vim:fenc=utf-8:ts=8:et:sw=4:sts=4
#
# Copyright © 2017 jpk <jpk@thor>
#
# Distributed under terms of the MIT license.

"""

"""

import sys
import time
from collections import namedtuple
from matplotlib import pyplot as plt
import numpy as np

from mc3000 import MC3000

TITLES = ('Voltage', 'Current (mAh)', 'Temperature')


if __name__ == '__main__':
    mc3k = MC3000()

    fig, slotplots = plt.subplots(nrows=3, ncols=4)
    plt.ion()

    battery_stats = []
    for row_index, slot in enumerate(slotplots):
        for slot_index, plot in enumerate(slot):
            plot.set_title(TITLES[row_index])
    for i in range(len(slotplots[0])):
        battery_stats.append({'voltage': [], 'current': [], 'bat_tem': []})
    print(battery_stats)

    fig.subplots_adjust(top=0.98, bottom=0.02, left=0.03, right=0.99, hspace=0.15, wspace=0.15)

    try:
        x_time = 0
        x_axis = []
        while True:
            try:
                batteries = mc3k.get_charging_progress(battery_slot='all')
            except:
                print('Error while reading from device. Skipping this cycle...')
                continue
            x_axis.append(x_time)
            x_time += 1
            for i, battery in enumerate(batteries):
                battery_stats[i]['voltage'].append(battery.voltage / 1000.0)
                battery_stats[i]['current'].append(battery.current / 1000.0)
                battery_stats[i]['bat_tem'].append(battery.bat_tem / 10.0)

                slotplots[0][i].plot(x_axis, battery_stats[i]['voltage'], color='r')
                slotplots[1][i].plot(x_axis, battery_stats[i]['current'], color='g')
                slotplots[2][i].plot(x_axis, battery_stats[i]['bat_tem'], color='b')
                if len(slotplots[0][i].lines) > 1:
                    slotplots[0][i].lines[0].remove()
                if len(slotplots[1][i].lines) > 1:
                    slotplots[1][i].lines[0].remove()
                if len(slotplots[2][i].lines) > 1:
                    slotplots[2][i].lines[0].remove()
            plt.pause(1)
    except KeyboardInterrupt:
        sys.exit(0)
