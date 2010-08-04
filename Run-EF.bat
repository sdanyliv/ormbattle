@echo off
set ReportsPath=..\..\..\_Reports
set Output=Output-EF
pushd TestRunner\bin\Release
  start /HIGH /WAIT cmd /C ..\..\..\Redirect.bat %ReportsPath%\%Output%.txt TestRunner.exe "-ppc:1" "-pc:50" "-lt:" "-t:EF" "-json:%ReportsPath%\json\%Output%.json"
popd
copy /Y "%ReportsPath%\%Output%.txt" .
