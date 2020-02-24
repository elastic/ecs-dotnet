#!/usr/bin/env bash
set -euo pipefail
build.sh test -v n -r target -d target/diag.log --no-build  --logger:"xunit;LogFilePath=TestResults.xml"
