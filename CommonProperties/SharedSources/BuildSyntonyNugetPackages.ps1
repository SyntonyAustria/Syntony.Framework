# This is a comment in Powershell
param (
    [string]$version = "0.1",
    [string]$server = "http://defaultserver",
<#
    [string]$username = $(throw "-username is required."),
    [string]$password = $( Read-Host "Input password, please" )
#>
    [switch]$force = $false )

Write-Host "Num Args:" $args.Length;
foreach ($arg in $args)
{
  Write-Host "Arg: $arg";
}

..\SharedBinaries\Tools\NuGet.exe pack Syntony.Framework.Assistance.nuspec -Verbosity Detailed -Version 0.1.0.1
..\SharedBinaries\Tools\NuGet.exe pack Syntony.Framework.nuspec -Verbosity Detailed -Version 0.1.0.1
..\SharedBinaries\Tools\NuGet.exe pack Syntony.Framework.CodeQuality.nuspec -Verbosity Detailed -Version 0.1.0.1
Copy -r *.nupkg ..\SharedBinaries\Syntony -passthru | foreach{$_.FullName; $len += ($_.length/1KB);}; Write-Host $len " Bytes kopiert"; $len=0;
del -r *.nupkg

pause