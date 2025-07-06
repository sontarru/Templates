# Templates

Advanced solution and project [templates](https://github.com/dotnet/templating) for
[.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

## Installation

### From the sources

Clone the repo:

```powershell
git clone https://github.com/sontarru/Templates.git
```

or

```powershell
gh repo clone sontarru/Templates
```

Invoke `dotnet new install` on the cloned repo directory:

```powershell
dotnet new install ./Templates
```

### From the NuGet package

```powershell
dotnet new install Sontar.Templates
```

### Check the templates installed

```powershell
dotnet new list
```

## Removal

How to remove the templates depends on the installation method.

### For installation from the sources

```powershell
dotnet new uninstall path/to/the/repo
```

### For installation from the NuGet package

```powershell
dotnet new uninstall Sontar.Templates
```

### Manual removal

Open the file `~/.templateengine/packages.json` and remove required element from the `Packages`
array.

For instance:

```json
{
    "Packages": [
        // The item below should be removed to uninstall templates manually:
        {
            "Details":null,
            "InstallerId":"f01dea33-e89c-46d1-89c2-1ca1f394c5aa",
            "LastChangeTime":"2025-07-04T00:53:52.663158Z",
            "MountPointUri":"C:\\Ololo\\Trololo\\TheTemplates"
        }
    ]
}
```

## Features

The included solution and project templates are supposed to work in conjunction and rely on the
certain solution layout. To get the solution template features working the solution "woriking"
projects should reside in the `./src` subdirectory of the solution, the test projects should be in
the `./test` subdirectory. Also in order that auto-referencing "testee" project works the test project
should be named `TesteeProject.Tests`. Below is the example of the layout:

```
MySolution.sln
src
  Foo
    Foo.csproj
  Bar
    Bar.csproj
test
  Foo.Tests
    Foo.Tests.csproj
  Bar.Tests
    Bar.Tests.csproj
```

1. Out of the box files for the generated solution: `global.json`, `.editorconfig`, `.gitignore`,
   boilerplates for `README.md` and `RELEASE-NOTES.txt`

1. [CPM (Central Package Management)](https://learn.microsoft.com/en-us/nuget/consume-packages/central-package-management)
   files: `nuget.config` and `Directory.Packages.props`.

1. Solution level build properties and settings that automatically applies to all solution projects
   (`./Directory.Build.props` and `./Directory.Solution.props`): common build properties (version,
   nullables, implicit usings, target framework version, common assembly attributes and package
   properties).

1. `./src` level build properties and settings:

   - Strict build settings (`TreatWarningsAsErrors`).

   - [Code and Style analysis](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/overview?tabs=net-9).

   - XML documentation file generation.

   - Settings for including `README.md` and `RELEASE-NOTES.txt` files to the built NuGet package.

1. `./test` level build properties and settings:

   - Auto-setting the root namespace of a test project to the name of the corresponding "testee"
     project.

   - Code coverage collection with the [Coverlet](https://github.com/coverlet-coverage/coverlet)
     framework.

   - Auto-referencing some packages required for test project:
     [Microsoft.NET.Test.Sdk](https://www.nuget.org/packages/Microsoft.NET.Test.Sdk),
     [xunit](https://www.nuget.org/packages/xunit),
     [xunit.runner.visualstudio](https://www.nuget.org/packages/xunit.runner.visualstudio).

   - Auto-referencing [FakeItEasy](https://www.nuget.org/packages/FakeItEasy) and
     [AwesomeAssertion](https://www.nuget.org/packages/AwesomeAssertions) packages.

   - Additional [implicit usings](https://learn.microsoft.com/en-us/dotnet/core/project-sdk/msbuild-props#implicitusings)
     for referenced packages.

   - Auto-referencing the corresponding "testee" project. If the test project is named e.g.
     `./test/Foo.Tests/Foo.Tests.csproj` and there's a project `.src/Foo/Foo.csproj` inside the `src`
     directory then the former one will be automatically referenced from the first.

1. Projects created from these templates with `dotnet new` automatically adds themselves to their
   solution.

Any properties and settings from `Directory.Build.props` files can be overwritten or extended at
the solution level in the `./Directory.Solution.props` file, at the `src` or `test` level in the
`./Directory.Src.props` and `./Directory.Test.props` files, or at the project level in the
particular `*.csproj` file.


