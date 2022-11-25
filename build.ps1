$dotnet = "$env:ProgramFiles\dotnet\dotnet.exe"
& $dotnet pack .\FkThat.Templates.csproj -o .\.Build --no-build
