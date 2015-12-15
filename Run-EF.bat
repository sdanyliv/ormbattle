@echo off
set ReportsPath=_Reports
set Output=Output-EF
pushd TestRunner\bin\Release
  set RootPath=..\..\..
  start /HIGH /WAIT cmd /C %RootPath%\Redirect.bat %RootPath%\%ReportsPath%\%Output%.txt TestRunner.exe "-ppc:1" "-t:EF6" "-json:%RootPath%\%ReportsPath%\json\%Output%.json"
popd
copy /Y "%ReportsPath%\%Output%.txt" .
