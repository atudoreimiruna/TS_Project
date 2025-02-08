@echo off

dotnet tool install -g dotnet-reportgenerator-globaltool

reportgenerator "-reports:./Results/coverage.lcov" "-targetdir:./Results/coverage-report"