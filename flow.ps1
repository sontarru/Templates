[CmdletBinding()]
param(
    [Parameter(Position = 0, Mandatory = $true)]
    [ValidateSet('start', 'finish', 'abort', 'rebase')]
    $Cmd,
    [Parameter(Position = 2, Mandatory = $false)]
    [string]
    $Name
)

$main = 'master'

# Get dirty files
$dirty = @()
$dirty += &{ git ls-files -o --exclude-standard }
$dirty += &{ git diff-index --name-only HEAD }

# Validate not dirty
if($dirty) {
    [System.Console]::Error.WriteLine("The folder is not clean. Commit or stash changes first.");
    exit 1
}

# Validate parameters
switch($Cmd) {
    'start' {
        if (-not $Name) {
            [System.Console]::Error.WriteLine('Missed $Name parameter.');
            exit 1
        }
    }
    # 'finish','abort','rebase'
    default {
        # fallback to the current branch
        if (-not $Name) {
            $Name = git branch --show-current
        }

        if($Name -eq $main) {
            [System.Console]::Error.WriteLine("Cannot $Cmd $main.");
            exit 1
        }
    }
}

# refresh the $main branch
git checkout $main && `
    git pull || `
    exit 1

switch($Cmd) {
    'start' {
        git checkout -b $Name && `
            git push -u origin $Name || `
            exit 1
    }
    'finish' {
        # clean remotes and delete the local feature branch
        git remote prune origin && `
            git branch -d $Name || `
            exit 1
    }
    'abort' {
        # delete remote and local branches, clean remotes
        git push -d origin $Name && `
            git remote prune origin && `
            git branch -d $Name || `
            exit 1
    }
    'rebase' {
        #rebase the local branch to the main branch
        git checkout $Name && `
            git rebase $main || `
            exit 1
    }
}
