@echo off
pushd TestRunner\bin\Release
  start /HIGH /WAIT cmd /C ..\..\..\Redirect.bat ..\..\..\Output.txt TestRunner.exe "-t:SQL,EF,LS,NH,OA,SS"
popd
