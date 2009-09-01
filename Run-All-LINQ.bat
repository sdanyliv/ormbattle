@echo off
pushd TestRunner\bin\Release
  start /HIGH /WAIT cmd /C ..\..\..\Redirect.bat ..\..\..\Output-All-LINQ.txt TestRunner.exe "-pt:" "-luc"
popd
