@echo off
pushd TestRunner\bin\Release
  start /HIGH cmd /C ..\..\..\Redirect.bat ..\..\..\Output.txt TestRunner.exe
popd
