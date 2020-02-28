echo off
set key=%1
set url=%2

@echo on
FOR /R ".\" %%a  in (*.nupkg) DO (
	dotnet nuget push "%%a" -k "%key%" -s "%url%"
)
