Get-ChildItem -Recurse -Filter *.csproj | ForEach-Object {
    dotnet restore $_ -p:TargetFramework=net7.0 && `
    dotnet build $_ '-p:TargetFramework=net7.0;Nullable=enable;ImplicitUsings=enable' --no-restore
}
