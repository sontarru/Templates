[CmdletBinding()]
param(
    # the command
    [Parameter(Position = 0, Mandatory = $true)]
    [ValidateSet('new-project')]
    $Command,
    # the command arguments
    [Parameter(ValueFromRemainingArguments = $true)]
    [string[]] $Arguments
)

# if no arguments passed
if(-not $Arguments) {
    $Arguments = @()
}

Push-Location $PSScriptRoot

try {
    switch($Command) {
        # create the project by the template along with the test project
        'new-project' {
            $template = $Arguments[0]
            $name = $Arguments[1]
            dotnet new ft-$template -o src\$name && `
            dotnet new ft-xunit -o test\Test.$name -tp $name && `
            dotnet sln add src\$name\$($name).csproj && `
            dotnet sln add test\Test.$name\Test.$($name).csproj
        }
    }
}
finally {
    Pop-Location
}
