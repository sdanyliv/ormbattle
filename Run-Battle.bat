@echo off
pushd TestRunner\bin\Release
  start /HIGH /WAIT cmd /C ..\..\..\Redirect.bat ..\..\..\Output.txt TestRunner.exe "-t:SQL,EF,L2S,BLT,LS,NH,OA,SS" "-ppt:5"
popd
