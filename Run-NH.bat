@echo off
set ReportsPath=_Reports
set Output=Output-NH
pushd TestRunner\bin\Release
  set RootPath=..\..\..
  start /HIGH /WAIT cmd /C %RootPath%\Redirect.bat %RootPath%\%ReportsPath%\%Output%.txt TestRunner.exe "-ppc:1" "-t:NH" "-json:%RootPath%\%ReportsPath%\json\%Output%.json"
popd
copy /Y "%ReportsPath%\%Output%.txt" .
