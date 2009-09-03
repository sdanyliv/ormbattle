@echo off
pushd TestRunner\bin\Release
  start /HIGH /WAIT cmd /C ..\..\..\Redirect.bat ..\..\..\Output.txt TestRunner.exe "-t:SQL,EF,BLT,LS,NH,OA,SS"
popd
