[CmdletBinding()]
param(
    [Parameter(Position = 0, Mandatory = $true)]
    [ValidateSet('start', 'finish', 'abort', 'rebase')]
    $Cmd,
    [Parameter(Position = 2, Mandatory = $false)]
    [string]
    $Name
)

Push-Location $PSScriptRoot

try {
    $main = 'master'
    $exeError = "Terminated due to the failure."

    # Get dirty files
    $dirty = @()
    $dirty += &{ git ls-files -o --exclude-standard }
    $dirty += &{ git diff-index --name-only HEAD }

    # Validate not dirty
    if($dirty) {
        throw "The folder is not clean. Commit or stash changes first."
    }

    # Validate parameters
    switch($Cmd) {
        'start' {
            if (-not $Name) {
                throw 'Missed $Name parameter.'
            }
        }
        # 'finish','abort','rebase'
        default {
            # fallback to the current branch
            if (-not $Name) {
                $Name = git branch --show-current
            }

            if($Name -eq $main) {
                throw "Cannot $Cmd $main."
            }
        }
    }

    # refresh the $main branch
    git checkout $main && `
        git pull || `
        &{ throw $exeError }
    
    switch($Cmd) {
        'start' {
            git checkout -b $Name && `
                git push -u origin $Name || `
                &{ throw $exeError }
        }
        # 'finish','abort','rebase'
        'finish' {
            # clean remotes and delete the local feature branch
            git remote prune origin && `
                git branch -d $Name || `
                &{ throw $exeError }
        }
        'abort' {
            # delete remote and local branches, clean remotes
            git push -d origin $Name && `
                git remote prune origin && `
                git branch -d $Name || `
                &{ throw $exeError }
        }
        'rebase' {
            #rebase the local branch to the main branch
            git checkout $Name && `
                git rebase $main || `
                &{ throw $exeError }
        }
    }
}
catch {
    Write-Error $_
}
finally {
    Pop-Location
}
