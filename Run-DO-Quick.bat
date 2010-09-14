@echo off
set ReportsPath=_Reports
set Output=Output-DO-Quick
pushd TestRunner\bin\Release
  set RootPath=..\..\..
  start /HIGH /WAIT cmd /C %RootPath%\Redirect.bat %RootPath%\%ReportsPath%\%Output%.txt TestRunner.exe "-t:DO" "-ppc:3" "-pi:1000,5000" "-json:%RootPath%\%ReportsPath%\json\%Output%.json"
popd
copy /Y "%ReportsPath%\%Output%.txt" .
