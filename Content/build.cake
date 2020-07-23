/*
#########################################################################################
Installing

dotnet tool Cake

    dotnet tool uninstall --global Cake.Tool
    dotnet tool install --global Cake.Tool

scripts/cake/common/install.cake
#########################################################################################
*/

//---------------------------------------------------------------------------------------
// Default target ("ci", "libs", ...)
string TARGET = Argument ("t", Argument ("target", "Default"));


string[] directories_to_clean = new string[]
{
    "./external/repos-downloaded/",
    "./output/",
    "./tools/",
    "./source/**/bin/",
    "./source/**/obj/",
    "./samples/**/bin/",
    "./samples/**/obj/",
    "./tests/**/bin/",
    "./tests/**/obj/",
    "./source/**/.vs/",
    "./samples/**/.vs/",
    "./tests/**/.vs/",
    "./source/**/.idea/",
    "./samples/**/.idea/",
    "./tests/**/.idea/",
    "./**/packages/",
};

string[] files_to_clean = new string[]
{
    "./**/*.binlog",
    "./**/.DS_Store",
};

string[] targets_to_run = new string[]
{
    "externals",
    "externals-build",
    "externals-git-clone",
    "externals-download",
    "libs",
    "samples",
    "nuget",
    "tests",
    "tests-unit-tests",
    "tests-unit-benchmarks",
};

string NUGET_VERSION="0.0.0.0";
//---------------------------------------------------------------------------------------
// source (library)
string source_solutions = $"./source/**/*Source.sln";
string source_projects = $"./source/**/*.csproj";

FilePathCollection SourceLibSolutions = GetFiles(source_solutions);
FilePathCollection SourceLibProjects  = GetFiles(source_projects);
//---------------------------------------------------------------------------------------

//---------------------------------------------------------------------------------------
string samples_solutions = $"./samples/**/*Sample*.sln";
string samples_projects  = $"./samples/**/*.csproj";

FilePathCollection SamplesSolutions = GetFiles(samples_solutions);
FilePathCollection SamplesProjects  = GetFiles(samples_projects);
//---------------------------------------------------------------------------------------


//---------------------------------------------------------------------------------------
// DO NOT CHANGE
#load "./scripts/cake/build.cake"
//---------------------------------------------------------------------------------------


// FilePathCollection UnitTestsNUnitMobileProjects = GetFiles($"./tests/unit-tests/project-references/**/*.NUnit.Xamarin*.csproj");
// FilePathCollection UnitTestsXUnitProjects = GetFiles($"./tests/unit-tests/project-references/**/*.XUnit.csproj");
// FilePathCollection UnitTestsMSTestProjects = GetFiles($"./tests/unit-tests/project-references/**/*.NUnit.csproj");


Task("Default")
.Does
    (
        () =>
        {
            foreach(string target_to_run in targets_to_run)
            {
                RunTarget($"{target_to_run}");
            }
        }
    );

RunTarget (TARGET);

if( ! IsRunningOnWindows())
{
    try
    {
        int exit_code = StartProcess
                                (
                                    "tree",
                                    new ProcessSettings
                                    {
                                        Arguments = @"./output"
                                    }
                                );
    }
    catch(Exception ex)
    {
        Information($"unable to start process - tree {ex.Message}");
    }
}
else
{
    // int exit_code = StartProcess
    //                         (
    //                             "dir",
    //                             new ProcessSettings
    //                             {
    //                                 Arguments = @"output"
    //                             }
    //                         );

}
