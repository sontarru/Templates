$myDocuments = [System.Environment]::GetFolderPath([System.Environment+SpecialFolder]::Personal)
$itemTemplates = "$myDocuments\Visual Studio 2022\Templates\ItemTemplates"

Remove-Item "$itemTemplates\*.FkThat.*."

Get-ChildItem $PSScriptRoot -Directory | ForEach-Object {
    $templateName = $_.Name
    $templateZip = "$itemTemplates\FkThat.Templates.VSItems.${templateName}.zip"
    Get-ChildItem $_ | Compress-Archive -DestinationPath $templateZip -Force
}
