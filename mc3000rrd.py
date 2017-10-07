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
import csv
import subprocess

from mc3000 import MC3000


RRD_CREATE = """rrdtool create {filename} --step=8 --start {start} \
DS:voltage:GAUGE:8:0:4200 \
DS:current:GAUGE:8:0:2000 \
DS:bat_tem:GAUGE:8:0:100 \
RRA:AVERAGE:0.5:1:1400"""

RRD_UPDATE = """rrdtool update {filename} {timestamp}:{voltage}:{current}:{bat_tem}"""

RRD_GRAPH = """rrdtool graph {png_file} --start {ts_start} --end {ts_end} --step 1 \
DEF:batvoltage={rrd_file}:voltage:LAST \
DEF:batcurrent={rrd_file}:current:LAST \
DEF:batbat_tem={rrd_file}:bat_tem:LAST \
LINE2:batvoltage#FF0000 \
LINE2:batcurrent#0000FF \
LINE1:batbat_tem#00FF00"""


def execute_rrd_cmd(command_line):
    subprocess.run(command_line.split(' '), stderr=subprocess.DEVNULL)


def create_rrd(filename, starttime):
    cmd = RRD_CREATE.format(filename=filename, start=starttime)
    execute_rrd_cmd(cmd)


def update_rrd(filename, battery):
    cmd = RRD_UPDATE.format(filename=filename, timestamp=battery['ts'],
                            voltage=int(float(battery['voltage']) * 1000),
                            current=int(float(battery['current']) * 1000),
                            bat_tem=int(float(battery['bat_tem']) * 10))
    execute_rrd_cmd(cmd)


def graph_rrd(png_file, rrd_file, starttime, endtime):
    cmd = RRD_GRAPH.format(png_file=png_file, rrd_file=rrd_file,
                           ts_start=starttime, ts_end=endtime)
    print(cmd)
    execute_rrd_cmd(cmd)


if __name__ == '__main__':
    try:
        filename = sys.argv[1]
    except IndexError:
        print('Not enough parameters.\n  Usage: {} <csv>\n'.format(sys.argv[0]))
        sys.exit(1)
    with open(filename, 'r') as csvfile:
        reader = csv.DictReader(csvfile, delimiter=' ', quotechar='|')
        for i, row in enumerate(reader):
            if i == 0:
                ts_start = row['ts']
                rrd_file = 'MC3000-{}-Battery_0.rrd'.format(ts_start)
                create_rrd(rrd_file, row['ts'])
            update_rrd(rrd_file, row)
            ts = row['ts']
        graph_rrd('MC3000-{}-Battery_0.png'.format(ts_start), rrd_file, ts_start, ts)
