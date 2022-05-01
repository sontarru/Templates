$name = "Foo.Bar"

if(Test-Path .test) {
    Remove-Item .test -Recurse
}

dotnet new ft-sln -o .test\${name}
dotnet new ft-classlib -o .test\${name}\src\${name}.ClassLib --packable
dotnet new ft-console -o .test\${name}\src\${name}.ConsoleApp
dotnet new ft-webapi -o .test\${name}\src\${name}.WebApi
dotnet new ft-worker -o .test\${name}\src\${name}.Workers
dotnet new ft-xunit -o .test\${name}\test\UnitTests.${name}.ClassLib
dotnet new ft-xunit -o .test\${name}\test\UnitTests.${name}.ConsoleApp
dotnet new ft-xunit -o .test\${name}\test\UnitTests.${name}.WebApi
dotnet new ft-xunit -o .test\${name}\test\UnitTests.${name}.Workers

Push-Location .test\$name
dotnet restore && `
dotnet build --no-restore && `
dotnet test --no-build && `
dotnet pack --no-build
Pop-Location
