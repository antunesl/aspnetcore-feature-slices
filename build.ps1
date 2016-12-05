function Exec
{
    [CmdletBinding()] param(
        [Parameter(Position=0,Mandatory=1)][scriptblock]$cmd,
        [Parameter(Position=1,Mandatory=0)][string]$errorMessage = ($msgs.error_bad_command -f $cmd)
    )
    & $cmd
    if ($lastexitcode -ne 0) {
        throw ("Exec: " + $errorMessage)
    }
}

exec { & dotnet restore }

exec { & dotnet build .\src\Core.FeatureSlices -c Release }

exec { & dotnet pack .\src\Core.FeatureSlices -c Release -o .\artifacts  }
