@echo off
set ReportsPath=..\..\..\_Reports
set Output=Output-DO
pushd TestRunner\bin\Release
  start /HIGH /WAIT cmd /C ..\..\..\Redirect.bat %ReportsPath%\%Output%.txt TestRunner.exe "-ppc:5" "-t:DO,EF,L2S,NH" "-json:%ReportsPath%\json\%Output%.js"
popd
copy /Y "%ReportsPath%\%Output%.txt" .
