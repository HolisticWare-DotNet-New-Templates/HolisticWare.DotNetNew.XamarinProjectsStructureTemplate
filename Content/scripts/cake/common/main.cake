
//---------------------------------------------------------------------------------------
Task ("clean")
    .Does
    (
        () =>
        {
            RunTarget("clean-folders");
            RunTarget("clean-files");
        }
    );

Task ("clean-folders")
    .Does
    (
        () =>
        {
            foreach(string directory_pattern in directories_to_clean)
            {
                DirectoryPathCollection directories = GetDirectories(directory_pattern);
                foreach(DirectoryPath dp in directories)
                {
                    Information($"Directory: {dp}");

                    if (DirectoryExists (dp))
                    {
                        DeleteDirectory
                                    (
                                        dp,
                                        new DeleteDirectorySettings
                                        {
                                            Recursive = true,
                                            Force = true
                                        }
                                    );
                    }
                }
            }


            return;
        }
    );

Task ("clean-files")
    .Does
    (
        () =>
        {
            foreach(string file_pattern in files_to_clean)
            {
                FilePathCollection files = GetFiles(file_pattern);
                foreach(FilePath fp in files)
                {
                    Information($"File: {fp}");

                    if (FileExists (fp))
                    {
                        DeleteFile (fp);
                    }
                }
            }


            return;
        }
    );
//---------------------------------------------------------------------------------------

