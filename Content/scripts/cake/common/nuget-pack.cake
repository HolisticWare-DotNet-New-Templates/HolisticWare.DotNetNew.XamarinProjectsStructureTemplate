
//---------------------------------------------------------------------------------------
Task("nuget-pack")
    .IsDependentOn ("nuget-pack")
    ;

Task("nuget-pack-msbuild")
    .Does
    (
        () =>
        {
            foreach(FilePath sln in SourceLibSolutions)
            {
                MSBuild
                (
                    sln.ToString(),
                    msbuild_settings 
                    =>
                    {
                        msbuild_settings
                            .SetConfiguration("Release")
                            .WithTarget("Pack")
                            .WithProperty("PackageVersion", NUGET_VERSION)
                            .WithProperty("PackageOutputPath", "../../output")
                            ;

                        return;
                    }
                );
            }

            return;
        }
    );

//---------------------------------------------------------------------------------------
