Get-ChildItem "$PSScriptRoot\src" |
    Where-Object { Test-Path "$_\.template.config" } |
    ForEach-Object {
        dotnet new -i $_ | Out-Null
    }

dotnet new -l |
    Select-String '^FkThat' -NoEmphasis
