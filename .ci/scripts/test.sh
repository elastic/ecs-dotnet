#!/usr/bin/env bash
#
# This script runs the tests and stored them in an xml file defined in the
# LogFilePath property
#
set -euo pipefail

./build.sh test -v n -r target -d target\diag.log --no-build
