#! /usr/bin/env python3
# -*- coding: utf-8 -*-
# vim:fenc=utf-8:ts=8:et:sw=4:sts=4
#
# Copyright © 2017 jpk <jpk@dwarf>
#
# Distributed under terms of the MIT license.

"""
MC3000 RRD Toolkit Library
--------------------------

RRD Tool library to create round robin databases and generate visual graphs of the charging
progress.
"""

import sys
import csv
import subprocess


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
AREA:batvoltage#FF0000:Voltage \
AREA:batcurrent#0000FF80:Current \
LINE1:batbat_tem#00FF00:Temperature"""


def execute_rrd_cmd(command_line):
    """Run *command_line* as arguments for **rrdtool** command.

    Command is executed as subprocess in backgroud.

    :param command_line: command line arguments for *rrdtool update*
    :type data_packet: str
    """
    print(command_line)
    subprocess.run(command_line.split(' '), stderr=subprocess.DEVNULL)


def create_rrd(filename, starttime):
    """Create a new RRD with *filename* and start collecting data since *starttime* timestamp.

    :param filename: Filename of the RRD file to be created
    :type filename: str
    """
    cmd = RRD_CREATE.format(filename=filename, start=starttime)
    execute_rrd_cmd(cmd)


def update_rrd(filename, battery):
    """Build the command line parameters with values to be stored in *filename* for each *battery*.

    :param filename: Filename of the RRD file to be updated
    :type filename: str
    :param battery: Index of the battery the values were read from
    :type battery: int
    """
    cmd = RRD_UPDATE.format(filename=filename, timestamp=battery['ts'],
                            voltage=int(float(battery['voltage']) * 1000),
                            current=int(float(battery['current']) * 1000),
                            bat_tem=int(float(battery['bat_tem']) * 10))
    execute_rrd_cmd(cmd)


def graph_rrd(png_file, rrd_file, starttime, endtime):
    """Render a PNG image with the values stored in *rrd_file* within the timestamp range of
    *starttime* and *endtime*. The resulting image will by stored with the filename *png_file*.

    :param png_file: Filename of the PNG image file
    :type png_file: str
    :param rrd_file: Filename of the RRD file to read the values from
    :type rrd_file: str
    :param starttime: Timestamp to start
    :type starttime: int
    :param endtime: Timestamp to stop
    :type endtime: int
    """
    cmd = RRD_GRAPH.format(png_file=png_file, rrd_file=rrd_file,
                           ts_start=starttime, ts_end=endtime)
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
