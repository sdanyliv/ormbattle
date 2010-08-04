@echo off
set ReportsPath=..\..\..\_Reports
set Output=Output-NH
pushd TestRunner\bin\Release
  start /HIGH /WAIT cmd /C ..\..\..\Redirect.bat %ReportsPath%\%Output%.txt TestRunner.exe "-ppc:1" "-t:NH" "-json:%ReportsPath%\json\%Output%.json"
popd
copy /Y "%ReportsPath%\%Output%.txt" .
