@echo off
set ReportsPath=_Reports
set Output=Output
pushd TestRunner\bin\Release
  set RootPath=..\..\..
  start /HIGH /WAIT cmd /C %RootPath%\Redirect.bat %RootPath%\%ReportsPath%\%Output%.txt TestRunner.exe "-ppc:5" "-json:%RootPath%\%ReportsPath%\json\%Output%.json"
popd
copy /Y "%ReportsPath%\%Output%.txt" .
