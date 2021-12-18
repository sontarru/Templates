[CmdletBinding()]
param(
    [Parameter(Position = 0)]
    [ValidateSet('clean', 'restore', 'install', 'reinit')]
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
            ForEach-Object { dotnet new -i $_ | Out-Null }

        dotnet new -l | Select-String '^FkThat' -NoEmphasis
    }
    'reinit' {
        dotnet Microsoft.TemplateEngine.Cli.CommandParsing.BaseCommandInput --debug:reinit
    }
}

