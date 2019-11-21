/*
run this

	dotnet cake --settings_skipverification=true

	export CAKE_SETTINGS_SKIPVERIFICATION=true
	dotnet cake
*/
#addin nuget:?package=Cake.FileHelpers
#addin "MagicChunks"

FilePathCollection files = null;
files = GetFiles("./*.nupkg");
DeleteFiles(files);

DateTime dt = DateTime.Now;

FilePath file = GetFiles ($"./*.nuspec").ToList () [0];	
Information($"{FileReadText(file)}");

string version = $"{dt.Year}.{dt.Month}.{dt.Day}.{dt.ToString("HHmm")}";

// https://github.com/xamarin/GoogleApisForiOSComponents/blob/master/update.cake
// XmlPoke
// (
// 	file,
//     "/ns:package/ns:metadata/ns:version/",
//     version,
//     new XmlPokeSettings 
// 	{
//         Namespaces = new Dictionary<string, string> 
// 		{
//             { "ns", "http://schemas.microsoft.com/packaging/2012/06/nuspec.xsd" },
//         }
//     }
// );

// https://github.com/sergeyzwezdin/magic-chunks
TransformConfig
(
	file.ToString(), 
	$"new.tmp.{version}.nuspec",
	new TransformationCollection 
	{
		{ "package/metadata/version", version },
	}
);

int exit_code = StartProcess
(
	"nuget", 
	new ProcessSettings
	{ 
		Arguments = $"pack new.tmp.{version}.nuspec" 
	}
);

// This should output 0 as valid arguments supplied
Information("Exit code: {0}", exit_code);

// NuGetPackSettings settings =
// 						new NuGetPackSettings 
// 									{
// 										Version = version
// 									}
// 						;
// NuGetPack
// (
// 	"./nuget/HolisticWare.DotNetNew.XamarinProjectsStructureTemplate.CSharp.nuspec",
// 	settings
// );

files = GetFiles("./new.tmp.*.nuspec");
DeleteFiles(files);
