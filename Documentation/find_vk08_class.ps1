$interopDir = 'd:\SteamLibrary\steamapps\common\Suikoden I and II HD Remaster\BepInEx\interop'
[System.AppDomain]::CurrentDomain.add_AssemblyResolve({
    param($sender, $args)
    $name = $args.Name.Split(',')[0]
    $path = Join-Path $interopDir "$name.dll"
    if (Test-Path $path) {
        return [System.Reflection.Assembly]::LoadFrom($path)
    }
    return $null
})

$asm = [System.Reflection.Assembly]::LoadFrom((Join-Path $interopDir 'GSD2.dll'))
foreach ($t in $asm.GetTypes()) {
    try {
        $fields = $t.GetFields([System.Reflection.BindingFlags]'Public,NonPublic,Static,Instance')
        foreach ($f in $fields) {
            if ($f.Name -like "*vk08*") {
                Write-Host "Found in Type: $($t.FullName) -> Field: $($f.Name)"
            }
        }
        $methods = $t.GetMethods([System.Reflection.BindingFlags]'Public,NonPublic,Static,Instance')
        foreach ($m in $methods) {
            if ($m.Name -like "*vk08*") {
                Write-Host "Found in Type: $($t.FullName) -> Method: $($m.Name)"
            }
        }
    } catch {}
}
