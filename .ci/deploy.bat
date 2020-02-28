echo off
set arg1=%1
set arg2=%2

@echo on
FOR /R ".\" %%a  in (*.nupkg) DO (
	echo dotnet nuget push "%%x" -k "%arg1%" -s "%arg2%"
)
