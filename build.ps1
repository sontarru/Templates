[CmdletBinding()]
param(
    [Parameter(Position = 0)]
    [ValidateSet('clean', 'restore', 'install',  'uninstall', 'reinit')]
    $Target = 'build'
)

switch($Target) {
    'clean' {
        Push-Location $PSScriptRoot
        git clean -dfx -e .vs -e .vscode
        Pop-Location
    }
    'restore' {
        Get-ChildItem "$PSScriptRoot\src" -Recurse -Filter *.csproj |
            ForEach-Object { dotnet restore $_ }
    }
    'install' {
        Get-ChildItem "$PSScriptRoot\src" |
            Where-Object { Test-Path "$_\.template.config" } |
            ForEach-Object { dotnet new -i $_ }

        dotnet new -l | Select-String '^FkThat' -NoEmphasis
    }
    'uninstall' {
        Get-ChildItem "$PSScriptRoot\src" |
            Where-Object { Test-Path "$_\.template.config" } |
            ForEach-Object { dotnet new -u $_.FullName }
    }   
    'reinit' {
        dotnet new --debug:reinit
    }
}

