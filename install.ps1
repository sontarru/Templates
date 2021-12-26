[CmdletBinding()]
param (
    [Parameter()]
    [switch]
    $Uninstall
)

$dotnet = "$env:ProgramFiles\dotnet\dotnet.exe"

if($Uninstall) {
    $switch = '-u'
}
else {
    $switch = '-i'
}

& $dotnet new $switch .
