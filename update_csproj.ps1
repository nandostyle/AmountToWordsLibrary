$csprojPath = "AmountToWordConverter_dotNETFramework\AmountToWordConverter_dotNETFramework.csproj"
$xmlContent = [xml](Get-Content $csprojPath)

# Update RootNamespace
$xmlContent.Project.PropertyGroup[0].RootNamespace = "NandoStyle.AmountToWords"
$xmlContent.Project.PropertyGroup[0].AssemblyName = "NandoStyle.AmountToWords"

# Add NuGet metadata properties
$propGroup = $xmlContent.Project.PropertyGroup[0]

# Create new elements if they don't exist
function EnsureElement($parent, $name, $value) {
	$elem = $parent.SelectSingleNode($name)
	if (-not $elem) {
		$elem = $xmlContent.CreateElement($name)
		$parent.AppendChild($elem) | Out-Null
	}
	$elem.InnerText = $value
}

EnsureElement $propGroup "GeneratePackageOnBuild" "True"
EnsureElement $propGroup "PackageId" "NandoStyle.AmountToWords"
EnsureElement $propGroup "Title" "Amount to Words Converter"
EnsureElement $propGroup "Version" "1.1.0.0"
EnsureElement $propGroup "AssemblyVersion" "1.1.0.0"
EnsureElement $propGroup "FileVersion" "1.1.0.0"
EnsureElement $propGroup "Authors" "Fernando J. Garcia"
EnsureElement $propGroup "Description" "A self-contained C#/.NET Framework 4.7.2 class library designed for easy integration into any .NET application. It converts decimal numbers into their word representation, handling multiple languages (English, Spanish) and currency formats (USD, MXN). Features include negative number support and plain number conversion mode."
EnsureElement $propGroup "PackageLicenseFile" "LICENSE.txt"
EnsureElement $propGroup "ProjectUrl" "https://github.com/nandostyle/AmountToWordsLibrary"
EnsureElement $propGroup "RepositoryUrl" "https://github.com/nandostyle/AmountToWordsLibrary"
EnsureElement $propGroup "RepositoryType" "git"
EnsureElement $propGroup "PackageTags" "amount;words;numbers;currency;conversion;spanish;english;i18n;localization"
EnsureElement $propGroup "PackageReleaseNotes" "v1.1.0.0 - Added ConversionMode enum for currency and plain number modes. Added support for negative numbers with language-specific prefixes. Added plain number conversion with decimal point/comma representation based on language."
EnsureElement $propGroup "IncludeSymbols" "true"
EnsureElement $propGroup "SymbolPackageFormat" "snupkg"

# Save the file
$xmlContent.Save($csprojPath)
Write-Host "Updated $csprojPath successfully"
