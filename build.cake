
Task ("nuget")
	.Does 
	(
		() => 
		{
			EnsureDirectoryExists ("./external/ios");

			DownloadFile (URL_IOS, "./external/ios");

			Unzip ("./external/ios/master.zip", "./external/ios/");
		}
	);
