echo off
set branchName="master"
set urlApi=https://localhost:44323/serveurs

:: recuperation du repo git 
git clone "https://github.com/Galambur/EPSI_TestIndustrialises_Restaurant.git"
git pull "https://github.com/Galambur/EPSI_TestIndustrialises_Restaurant" %branchName% 

cd EPSI_TestIndustrialises_Restaurant
dotnet msbuild -t:Restore Restaurant.sln
dotnet msbuild Restaurant.sln>build.txt
for /F "UseBackQ Delims==" %%A in ("build.txt") do set "lastlineBuild=%%A"
for /F "tokens=1" %%a in ("%lastlineBuild%") do set resultBuild=%%a 
if not "%resultBuild%" == "RestaurantTest " EXIT /B

dotnet test>tests.txt
for /F "UseBackQ Delims==" %%A in ("tests.txt") do set "lastlineTest=%%A"
for /F "tokens=1" %%a in ("%lastlineTest%") do set resultTest=%%a 
chcp 65001
if not "%resultTest%" == "Réussi! " EXIT /B

echo on
PowerShell -Command "(new-object net.webclient).DownloadString('%urlApi%')

pause