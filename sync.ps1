".editorconfig",
".gitignore",
"Directory.Build.props",
"Directory.Packages.props",
"global.json",
"LICENSE",
"nuget.config",
"src\Directory.Build.props",
"test\Directory.Build.props" |
    ForEach-Object {
        Copy-Item "$PSScriptRoot\$_" `
            "$PSScriptRoot\src\FkThat.Templates.Solution\$_"
    }
