[CmdletBinding()]
param(
    [Parameter(Position = 0)]
    [ValidateSet('clean', 'restore', 'build', 'test', 'cover')]
    $Target = 'build',
    [Parameter()]
    [ValidateSet('Debug', 'Release')]
    $Config = 'Debug'
)

switch($Target) {
    'clean' {
        git clean -dfx -e .vs -e .vscode
    }
    'restore' {
        dotnet restore
    }
    'build' {
        dotnet build -c $Config
    }
    'test' {
        dotnet test -c $Config --logger:trx
    }
    'cover' {
        dotnet tool restore &&
        dotnet tool run reportgenerator `
            -reports:test\**\TestResults\coverage.cobertura.xml `
            -targetdir:TestResults\html && `
            Start-Process 'TestResults\index.htm'
    }
    'pack' {
        dotnet pack -c $Config -o '.build'
    }
}
