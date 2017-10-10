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
import csv
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
        battery_stats.append({'voltage': [], 'current': [], 'bat_tem': [], 'ts': []})
    print(battery_stats)

    fig.subplots_adjust(top=0.98, bottom=0.02, left=0.06, right=0.99, hspace=0.15, wspace=0.15)

    battery_fd = []
    for i in range(len(slotplots[0])):
        timestamp = int(time.time())
        fields = ['ts', 'voltage', 'current', 'bat_tem']
        csvfile = csv.DictWriter(open('Battery-{}_{}.csv'.format(timestamp, i), 'w', newline=''),
                                 delimiter=';', quotechar='|', quoting=csv.QUOTE_MINIMAL,
                                 fieldnames=fields)
        csvfile.writeheader()
        battery_fd.append(csvfile)

    try:
        x_time = 0
        x_axis = []
        while True:
            try:
                timestamp = int(time.time())
                batteries = mc3k.get_charging_progress(battery_slot='all')
            except:
                print('Error while reading from device. Skipping this cycle...')
                continue
            x_axis.append(x_time)
            x_time += 1
            for i, battery in enumerate(batteries):
                voltage = battery.voltage / 1000.0
                current = battery.current / 1000.0
                bat_tem = battery.bat_tem / 10.0
                battery_stats[i]['voltage'].append(voltage)
                battery_stats[i]['current'].append(current)
                battery_stats[i]['bat_tem'].append(bat_tem)
                battery_stats[i]['ts'].append(timestamp)

                if battery.work > 0 and i == battery.slot:
                    battery_fd[i].writerow({'voltage': voltage, 'current': current,
                                            'bat_tem': bat_tem, 'ts': timestamp})

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
            plt.tight_layout()
    except KeyboardInterrupt:
        sys.exit(0)
