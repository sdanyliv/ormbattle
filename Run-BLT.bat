@echo off
pushd TestRunner\bin\Release
  start /HIGH /WAIT cmd /C ..\..\..\Redirect.bat ..\..\..\Output-BLT.txt TestRunner.exe "-t:BLT,L2S" "-ppc:2"
  rem start /HIGH /WAIT cmd /C TestRunner.exe "-t:BLT,EF,L2S" "-ppc:2"
popd
