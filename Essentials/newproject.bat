dotnet new sln -o MySolution
cd MySolution
mkdir src
dotnet new console -lang F# -o src/MyProject
dotnet sln add src/MyProject/MyProject.fsproj
mkdir tests
dotnet new xunit -lang F# -o tests/MyProjectTests
dotnet sln add tests/MyProjectTests/MyProjectTests.fsproj
cd tests/MyProjectTests
dotnet add reference ../../src/MyProject/MyProject.fsproj
dotnet add package Xunit
dotnet add package FsUnit.XUnit
dotnet build
dotnet test
