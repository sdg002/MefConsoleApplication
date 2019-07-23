
echo off
rem This will copy over the compiled output of plugins to the central plugins folder
echo Launching script to copy over plugins
set SOLNFOLDER=%1
set PLUGINFOLDER=%2
set PLUGINNAME=%3
set CONFIG=%4
rem Displaying all variables
echo SOLNFOLDER=%SOLNFOLDER%
echo PLUGINFOLDER=%PLUGINFOLDER%
echo PLUGINNAME=%PLUGINNAME%
echo CONFIG=%CONFIG%
set EXEOUTPUT=%SOLNFOLDER%\MefDemoWithPluginsFolder.Main\Bin\%CONFIG%\netcoreapp2.1
rem if not exist %SOLNFOLDER%  echo "Folder %SOLNFOLDER% was not found" & exit /b 1
echo Testing for SOLNFOLDER=%SOLNFOLDER%
if not exist %SOLNFOLDER%  (
	echo "Solution folder:%SOLNFOLDER% was not found"
	echo Quitting
	exit /b 1
)
echo Ok with soltuion folder
echo Testing for PLUGINFOLDER=%PLUGINFOLDER%
if not exist %PLUGINFOLDER%  (
	echo "Plugin src folder folder:%PLUGINFOLDER% was not found"
	echo Quitting
	exit /b 1
)
echo Ok with Plugin src folder
echo testing for EXEOUTPUT=%EXEOUTPUT%
if not exist %EXEOUTPUT%  (
	echo "Executable output folder :%EXEOUTPUT% was not found"
	echo Quitting
	exit /b 1
)
 set destination="%solnfolder%\MefDemoWithPluginsFolder.Main\bin\%config%\netcoreapp2.1\plugins\%pluginname%"

 if exist %destination%  (
	echo Deleting files in DESTINATION=%destination%
	del /s /q  %destination%
 )
if not exist %destination%  (
	echo final destination folder=%destination% was not found
	mkdir %DESTINATION%
)
echo All folders valid
REM if   EXIST %DESTINATION% (
	REM rmdir /s /q %DESTINATION%
	REM echo Destination folder removed
REM )

echo Going to copy from 
echo SOURCE=%PLUGINFOLDER%
echo DESTINATION=%DESTINATION%

echo Copying Plugins from %PLUGINFOLDER% to %DESTINATION%
xcopy  "%PLUGINFOLDER%*.*"  %DESTINATION% /s /v /e /y
exit /b 0

