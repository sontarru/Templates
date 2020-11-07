[CmdletBinding()]
param (
    [Parameter(Position = 0)]
    [ValidateSet('restore', 'build', 'test', 'clean', 'pack', 'run', 'watch')]
    $Target = 'build',

    [Parameter()]
    [ValidateSet('Debug', 'Release')] 
    $Config = 'Debug',

    [Parameter()]
    [Switch] 
    $ShowCoverageReport,

    [Parameter()]
    [string]
    $StartProject,

    [Parameter()]
    [string]
    $LaunchProfile
)

if($Target -eq 'run' || $Target -eq 'watch') {
    if(-not $StartProject) {
        Write-Error '-StartProject parameter required'
        break
    }

    $StartProject = (Get-Item $StartProject).FullName
}

Push-Location $PSScriptRoot

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
        dotnet test -c $Config || break

        if($ShowCoverageReport) {
            dotnet tool restore &&

            dotnet tool run reportgenerator `
                -reports:**\coverage.cobertura.xml `
                -targetdir:.coverage &&

            Start-Process '.coverage\index.htm'
        }
    }
    'pack' {
        dotnet test -c $Config &&
        dotnet pack -c $Config -o '.build' --no-build
    }
    'run' {
        dotnet run -c $Config -p $StartProject --launch-profile $LaunchProfile
    }
    'watch' {
        dotnet watch -p $StartProject run -c $Config --launch-profile $LaunchProfile
    }
}

Pop-Location
