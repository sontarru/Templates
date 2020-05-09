$TemplateDir = "${env:USERPROFILE}\Documents\Visual Studio 2019\Templates\ItemTemplates"

Get-ChildItem $PSScriptRoot -Directory | ForEach-Object {
    $TemplateName = $_.Name
    $TemplateZip = "$TemplateDir\FkThat.Templates.VSItems.${TemplateName}.zip"
    Get-ChildItem $_ | Compress-Archive -DestinationPath $TemplateZip -Force
}