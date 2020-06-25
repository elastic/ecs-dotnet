#!/usr/bin/env bash
#
# This script deploys to nuget given the API key and URL
#
set -euo pipefail

while IFS= read -r -d '' nupkg
do
    echo "dotnet nuget push ${nupkg}"
    dotnet nuget push "${nupkg}" -k "${1}" -s "${2}" --skip-duplicate
done < <(find . -type f -not -path './build/output/*' -name '*.nupkg' -print0)
