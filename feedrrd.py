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
import csv


try:
    filename = sys.argv[1]
except IndexError:
    print('Not enough parameters.\n  Usage: {} <csv>\n'.format(sys.argv[0]))
    sys.exit(1)

with open(filename, 'r') as csvfile:
    reader = csv.DictReader(csvfile, delimiter=' ', quotechar='|')
    for row in reader:
        print('{}:{:d}'.format(row['ts'], int(float(row['voltage']) * 1000)))
