@echo off
pushd TestRunner\bin\Release
  start /WAIT cmd /C ..\..\..\Redirect.bat ..\..\..\Output-All.txt TestRunner.exe
popd
