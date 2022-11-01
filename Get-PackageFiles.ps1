Get-ChildItem .\templates -File -Recurse |
    Where-Object FullName -NotMatch '(\\bin\\|\\obj\\)' |
    Select-Object -ExpandProperty FullName |
    ForEach-Object { [System.IO.Path]::GetRelativePath('.', $_) -replace "\\","/" }
