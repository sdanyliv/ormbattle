@echo off
pushd TestRunner\bin\Release
  start /HIGH cmd /C ..\..\..\Redirect.bat ..\..\..\Output.txt TestRunner.exe -t:EF,LS,NH,OA,SS
popd
