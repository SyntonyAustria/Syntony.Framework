#Script parameters
$mydocs = [Environment]::GetFolderPath("MyDocuments")
$datestring = Get-Date -format yyyy-MM-dd
$scriptpath = $MyInvocation.MyCommand.Path
$script_dir = Split-Path $scriptpath

# create folder structure
#		====================================================================================================================================================================================
#						SINGLE Solution Environment Folder Structure
#		====================================================================================================================================================================================
#		Company (Syntony)
#			TeamProjectName (Framework)
#				Branch (Main, Release, Development, etc.) (.sln file)
#					CommonProperties
#						SharedSources (here Syntony.Common.props must be stored)
#						SharedBinaries
#							Packages
#							Tools
#							Company
#					Source
#						ProjectName1 (Core)
#							Source (.csproj file)  ...  from here:  ..\..\..\CommonProperties\SharedSources\Syntony.Common.props
#								Properties
#								bin
#								obj
#								Core
#								...
#							Doc
#							IntegrationTests (integration tests for all project modules) 
#								Properties
#								bin
#								obj
#								...
#							UnitTests (Unit tests for all project modules)
#								Properties
#								bin
#								obj
#								...
#							AutomationTests (tests that invoke the UI)
#								Properties
#								bin
#								obj
#								...
#						ProjectName2 
#							Source (.csproj file)
#								Properties
#								bin
#								obj
#								Core
#								...
#							Doc
#							IntegrationTests (integration tests for all project modules) 
#								Properties
#								bin
#								obj
#								...
#							UnitTests (Unit tests for all project modules)
#								Properties
#								bin
#								obj
#								...
#							AutomationTests (tests that invoke the UI)
#								Properties
#								bin
#								obj
#								...
#					IntegrationTests (integration tests for all modules of the current solution) 
#						Properties
#						bin
#						obj
#						Core
#						...
#					TrialAndErrorConsole
#					Warehouse - NOT Compile
$teamProjectName = "Framework"
$branch = "Main"



New-Item -ItemType Directory -Path ".\FolderX\FolderY\FolderZ"

$di = [System.IO.FileInfo]"$(split-path $Profile -Parent)\desktop.ini"
set-content $di "[.ShellClassInfo]`r`nLocalizedResourceName=1$([char]160)WindowsPowerShell`r`nIconResource=C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe,0`r`n[ViewState]`r`nFolderType=Documents"
$di.Attributes = $di.Attributes -bor [IO.FileAttributes]"System,Hidden" -bxor [IO.FileAttributes]"Archive"