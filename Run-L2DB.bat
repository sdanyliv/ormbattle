@echo off
pushd TestRunner\bin\Release
  start /HIGH /WAIT cmd /C ..\..\..\Redirect.bat ..\..\..\Output-L2DB.txt TestRunner.exe "-t:BLT,L2DB" "-ppc:2"
  rem start /HIGH /WAIT cmd /C TestRunner.exe "-t:BLT,L2DB" "-ppc:2"
popd
