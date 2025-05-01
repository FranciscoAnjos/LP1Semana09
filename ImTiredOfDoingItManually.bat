@echo off
:: Check if the argument is provided
if "%1"=="" (
    echo Please provide the project name as an argument.
    exit /b 1
)

:: Store the project name into a variable
set "NomeDoProjeto=%1"

:: Run the commands
echo Creating a new project...
dotnet new lp1console --name %NomeDoProjeto%

echo Adding project to the solution...
dotnet sln add %NomeDoProjeto%

echo Building the project...
dotnet build %NomeDoProjeto%

echo Done!
pause
