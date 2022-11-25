$dotnet = "$env:ProgramFiles\dotnet\dotnet.exe"
& $dotnet pack .\FkThat.Templates.csproj -o .\.build -p:Version=0.0.42
