@echo off
pushd TestRunner\bin\Release
  start /HIGH /WAIT cmd /C ..\..\..\Redirect.bat ..\..\..\Output.txt TestRunner.exe "-json" "-ppc:5"
popd
