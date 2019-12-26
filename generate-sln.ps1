#
# Set a solution name.
#
$SolutionName = "All-Project"

#
# Delete old one if it exists.
#
if (Test-Path "$SolutionName.sln")
{
    Remove-Item "$SolutionName.sln"
}

#
# Create a new solution file.
#
dotnet new sln --name $SolutionName

#
# Find csproj file.
#
foreach ($f in Get-ChildItem -Path $scriptPath -Recurse -Filter *.csproj)
{
    dotnet sln "$SolutionName.sln" add --in-root $f.FullName
}
