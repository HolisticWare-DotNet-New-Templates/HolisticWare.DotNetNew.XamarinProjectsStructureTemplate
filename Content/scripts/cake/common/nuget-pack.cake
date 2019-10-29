string NUGET_VERSION="0.0.0.0";

//---------------------------------------------------------------------------------------
Task("nuget")
    .IsDependentOn ("nuget-pack")
    ;

Task("nuget-pack")
    .IsDependentOn ("nuget-pack-solution")
    .IsDependentOn ("nuget-pack-projects")
    ;
    
Task("nuget-pack-solution")
    .Does
    (
        () =>
        {
            foreach(FilePath sln in SourceLibSolutions)
            {
                Information($"Packaging NuGEt {sln.GetFilename()}");
                MSBuild
                (
                    sln.ToString(),
                    msbuild_settings =>
                    {
                        msbuild_settings
                            .SetConfiguration("Release")
                            .WithTarget("Pack")
                            .WithProperty("PackageVersion", NUGET_VERSION)
                            .WithProperty("PackageOutputPath", "../../output")
                            ;
                    }
                );
            }

            return;
        }
    );
Task("nuget-pack-projects")
    .Does
    (
        () =>
        {
            foreach(FilePath prj in SourceLibProjects)
            {
                Information($"Packaging NuGEt {prj.GetFilename()}");
                MSBuild
                (
                    prj.ToString(),
                    msbuild_settings =>
                    {
                        msbuild_settings
                            .SetConfiguration("Release")
                            .WithTarget("Pack")
                            .WithProperty("PackageVersion", NUGET_VERSION)
                            .WithProperty("PackageOutputPath", "../../output")
                            ;
                    }
                );
            }

            return;
        }
    );

//---------------------------------------------------------------------------------------
