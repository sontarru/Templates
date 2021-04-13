[CmdletBinding()]
param(
    [Parameter(Position = 0, Mandatory = $true)]
    [ValidateSet('start-feature', 'finish-feature', 'new-project')]
    $Command,
    [Parameter(ValueFromRemainingArguments = $true)]
    [string[]]
    $Args
)

Push-Location $PSScriptRoot

try {
    switch($Command) {
        'start-feature' {
            $name = $Args[0]
            git checkout develop && `
            git checkout -b feature/$name && `
            git push -u origin feature/$name
        }
        'finish-feature' {
            git checkout develop && `
            git pull && `
            git remote prune origin && `
            git branch -d feature/$($Args[0])
        }
        'new-project' {
            $templ = $Args[0]
            $name = $Args[1]
            dotnet new ft-$templ -o src\$name && `
            dotnet new ft-xunit -o test\Test.$name -tp $name && `
            dotnet sln add src\$name\$($name).csproj && `
            dotnet sln add test\Test.$name\Test.$($name).csproj
        }
    }
}
finally {
    Pop-Location
}

