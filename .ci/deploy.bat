echo off
set arg1=%1
set arg2=%2

@echo on
for /r %%x in (.\build\output\_packages\*.nupkg) do echo "%%x"
echo dotnet nuget push blabla -k ${arg1} -s ${arg2}
