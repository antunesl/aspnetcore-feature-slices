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
exec { & dotnet build .\src\Mvc.RazorFeatures -c Release }
exec { & dotnet pack .\src\Mvc.RazorFeatures -c Release -o .\artifacts  }
