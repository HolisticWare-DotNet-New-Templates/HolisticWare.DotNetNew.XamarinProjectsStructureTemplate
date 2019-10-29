#load "./nuget-restore.cake"


string[] configs = new string[]
{
    "Debug",
    "Release"
};

//---------------------------------------------------------------------------------------
Task("libs")
    .IsDependentOn ("nuget-restore-libs")
    .IsDependentOn ("libs-msbuild-solutions")
    .IsDependentOn ("libs-msbuild-projects")
    .IsDependentOn ("libs-dotnet-solutions")
    .IsDependentOn ("libs-dotnet-projects")
    .Does
    (
        () =>
        {
            return;
        }
    );


Task("libs-msbuild-solutions")
    .Does
    (
        () =>
        {
            foreach(FilePath sln in SourceLibSolutions)
            {
                string binlog_path = "../output/holisticware-source-build-{sln}.binlog";
				foreach (string config in configs)
                {
                    MSBuild
                    (
                        sln.ToString(),
                        /*
                        Action
                        msbuild_settings =>
                        {
                            msbuild_settings.Configuration = config;
                            msbuild_settings.MaxCpuCount = 0;
                            msbuild_settings.Targets.Clear();
                            msbuild_settings.Targets.Add("Pack");
                            msbuild_settings.Properties.Add
                                                            (
                                                                "PackageOutputPath",
                                                                new []
                                                                {
                                                                    MakeAbsolute(new FilePath("../output")).FullPath
                                                                }
                                                            );
                        }
                        */
                        new MSBuildSettings
                                    {
                                        Configuration = config,
                                        Verbosity = Verbosity.Diagnostic,
                                        BinaryLogger = new MSBuildBinaryLogSettings
                                        {
                                            Enabled = true,
                                            FileName = new FilePath(binlog_path).FullPath
                                        }
                                    }
                                    .WithProperty
                                                (
                                                    "DefineConstants",
                                                    "TRACE;" //"DEBUG;NETCOREAPP2_0;NUNIT"
                                                )

                    );
                }
            }

            return;
        }
    );

Task("libs-dotnet-solutions")
    .Does
    (
        () =>
        {
            foreach(FilePath sln in SourceLibSolutions)
            {
				foreach (string config in configs)
                {
                    DotNetCoreBuild
                    (
                        sln.ToString(),
                        new DotNetCoreBuildSettings
                        {
                            Configuration = config,
                        }
                        //.WithProperty("DefineConstants", "TRACE;DEBUG;NETCOREAPP2_0;NUNIT")
                    );
                }
            }

            return;
        }
    );

Task("libs-msbuild-projects")
    .Does
    (
        () =>
        {
            foreach(FilePath prj in SourceLibProjects)
            {
                MSBuild
                (
                    prj.ToString(),
                    new MSBuildSettings
                    {
                        Configuration = "Debug",
                    }
                    //.WithProperty("DefineConstants", "TRACE;DEBUG;NETCOREAPP2_0;NUNIT")
                );
                MSBuild
                (
                    prj.ToString(),
                    new MSBuildSettings
                    {
                        Configuration = "Release",
                    }
                    //.WithProperty("DefineConstants", "TRACE;DEBUG;NETCOREAPP2_0;NUNIT")
                );
            }

            return;
        }
    );

Task("libs-dotnet-projects")
    .Does
    (
        () =>
        {
            foreach(FilePath prj in SourceLibProjects)
            {
                DotNetCoreBuild
                (
                    prj.ToString(),
                    new DotNetCoreBuildSettings
                    {
                        Configuration = "Debug",
                    }
                    //.WithProperty("DefineConstants", "TRACE;DEBUG;NETCOREAPP2_0;NUNIT")
                );
                DotNetCoreBuild
                (
                    prj.ToString(),
                    new DotNetCoreBuildSettings
                    {
                        Configuration = "Release",
                    }
                    //.WithProperty("DefineConstants", "TRACE;DEBUG;NETCOREAPP2_0;NUNIT")
                );
            }

            return;
        }
    );

public void Build(string pattern)
{
	FilePathCollection files = GetFiles(pattern);

	foreach(FilePath file in files)
	{
		foreach (string config in configs)
		{
			MSBuild
			(
				file.ToString(),
				new MSBuildSettings
				{
					Configuration = config,
				}
				//.WithProperty("DefineConstants", "TRACE;DEBUG;NETCOREAPP2_0;NUNIT")
				.WithProperty("AndroidClassParser", "jar2xml")

			);
		}
	}

	return;
}
//---------------------------------------------------------------------------------------
