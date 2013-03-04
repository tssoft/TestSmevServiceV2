del SmevUtils.*.nupkg
del *.nuspec
del .\Utils\bin\Release\*.nuspec

function GetNodeValue([xml]$xml, [string]$xpath)
{
	return $xml.SelectSingleNode($xpath).'#text'
}

function SetNodeValue([xml]$xml, [string]$xpath, [string]$value)
{
	$node = $xml.SelectSingleNode($xpath)
	if ($node) {
		$node.'#text' = $value
	}
}

Remove-Item .\Utils\bin -Recurse 
Remove-Item .\Utils\obj -Recurse

$build = "c:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe ""Utils\SmevUtils.csproj"" /p:Configuration=Release" 
Invoke-Expression $build

$Artifact = (resolve-path ".\Utils\bin\Release\SmevUtils.dll").path

nuget spec -F -A $Artifact

Copy-Item .\SmevUtils.nuspec.xml .\Utils\bin\Release\SmevUtils.nuspec

$GeneratedSpecification = (resolve-path ".\SmevUtils.nuspec").path
$TargetSpecification = (resolve-path ".\Utils\bin\Release\SmevUtils.nuspec").path

[xml]$srcxml = Get-Content $GeneratedSpecification
[xml]$destxml = Get-Content $TargetSpecification
$value = GetNodeValue $srcxml "//version"
SetNodeValue $destxml "//version" $value;
$value = GetNodeValue $srcxml "//description"
SetNodeValue $destxml "//description" $value;
$value = GetNodeValue $srcxml "//copyright"
SetNodeValue $destxml "//copyright" $value;
$destxml.Save($TargetSpecification)

nuget pack $TargetSpecification

del *.nuspec
del .\Utils\bin\Release\*.nuspec

exit
