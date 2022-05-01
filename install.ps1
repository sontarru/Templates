[CmdletBinding()]
param (
    [Parameter()]
    [switch]
    $Uninstall
)

if($Uninstall) {
    $switch = '-u'
}
else {
    $switch = '-i'
}

dotnet new $switch .
