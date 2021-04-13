[CmdletBinding()]
param(
    [Parameter(Position = 0, Mandatory = $true)]
    [ValidateSet('start-feature', 'finish-feature')]
    $Command,
    [Parameter(ValueFromRemainingArguments = $true)]
    [string[]]
    $Args
)

Push-Location $PSScriptRoot

try {
    switch($Command) {
        'start-feature' {
            git checkout develop && `
            git checkout -b feature/$Args[0]
        }
        'finish-feature' {
            git checkout develop && `
            git pull && `
            git remote prune origin && `
            git branch -d feature/$Args[0]
        }
        'new-project' {
            dotnet new ft-$Args[0] -o src\$Args[1] && `
            dotnet new ft-xunit -o test\Test.$Args[1] -tp $Args[1] && `
            dotnet sln add src\$Args[1]\$Args[1].csproj && `
            dotnet sln add test\Test.$Args[1]\Test.$Args[1].csproj
        }
    }
}
finally {
    Pop-Location
}

