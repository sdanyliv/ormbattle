function Kill-Accessors
{
  write "Killing processes that might use the repository..."
  Get-Process -ErrorAction SilentlyContinue -Name `
    devenv, `
    MSBuild, `
    postsharp.srv.*, `
    Xtensive.Licensing.Manager |
    foreach {
      write ("  Killing: {0}" -f $_.Name)
      Stop-Process -Force -ErrorAction Stop -InputObject $_
    }
}
