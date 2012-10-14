:: AdventureWorks
::@echo off

SET DIR=%~d0%~p0%

SET database.name="Sfasystem"
SET sql.files.directory="..\db\"
SET server.database="localhost"
SET rh.path= "%DIR%..\..\..\..\Tools\RoundhousE\console\"
SET restore.path=%DIR%..\..\..\DatabaseBackups\
SET restore.name=AdventureWorks.bak

:: Run RH in RestoreRun mode
%rh.path%\rh.exe /s=%server.database% /d=%database.name% -f ..\db --debug /restore /rfp=%restore.path%\%restore.name% /simple
