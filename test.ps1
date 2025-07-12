$ErrorActionPreference = 'Stop'

$dotnet = $IsWindows ?
    "$env:ProgramFiles\dotnet\dotnet.exe" :
    (which dotnet)

if(-not (Get-Command $dotnet -ErrorAction SilentlyContinue)) {
    Write-Error "'$dotnet' executable not found."
}

& $dotnet new Sontar.Sln -o Foo

Get-ChildItem templates -Directory -Exclude *.Sln,*.XU | ForEach-Object {
    $templ = $_.Name
    $proj = Join-Path "Foo" "src" $templ
    $xu = Join-Path "Foo" "test" "$templ.Tests"

    & $dotnet new $templ -o $proj
    & $dotnet new Sontar.XU -o $xu

    $cs = @"
namespace $templ;

public class FooTests
{
    [Fact]
    public void TwoByTwo_is_four()
    {
        (2 * 2).Should().Be(4);
    }
}
"@

    Set-Content (Join-Path "$xu" "FooTests.cs") -Value $cs -Force
}

& $dotnet restore Foo
& $dotnet build Foo --no-restore
& $dotnet test Foo --no-build
