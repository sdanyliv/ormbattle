@echo off
pushd TestRunner\bin\Release
  start /HIGH /WAIT cmd /C ..\..\..\Redirect.bat ..\..\..\Output-All.txt TestRunner.exe
popd
