Get-ChildItem .\test\ -Directory | ForEach-Object {
    dotnet test $_.FullName
}