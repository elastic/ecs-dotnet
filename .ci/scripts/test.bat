::
:: This script runs the tests and stored them in an xml file defined in the
:: LogFilePath property
::
build.bat test -v n -r target -d target\diag.log --no-build ^
 --logger:"xunit;LogFilePath=TestResults.xml"
