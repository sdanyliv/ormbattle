@echo off
pushd TestRunner\bin\Release
  start /HIGH /WAIT cmd /C ..\..\..\Redirect.bat ..\..\..\Output-LINQ.txt TestRunner.exe "-pt:" "-luc"
popd
