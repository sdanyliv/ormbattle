@echo off
pushd TestRunner\bin\Release
  start /WAIT cmd /C ..\..\..\Redirect.bat ..\..\..\Output-All-LINQ.txt TestRunner.exe "-pt:" "-luc"
popd
