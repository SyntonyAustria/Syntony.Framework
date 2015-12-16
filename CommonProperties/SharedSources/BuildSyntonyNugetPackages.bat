..\SharedBinaries\Tools\NuGet.exe pack Syntony.Framework.Assistance.nuspec -Verbosity Detailed -Version 0.1.0.1
..\SharedBinaries\Tools\NuGet.exe pack Syntony.Framework.nuspec -Verbosity Detailed -Version 0.1.0.1
..\SharedBinaries\Tools\NuGet.exe pack Syntony.Framework.CodeQuality.nuspec -Verbosity Detailed -Version 0.1.0.1
move /y *.nupkg ..\SharedBinaries\Syntony
pause