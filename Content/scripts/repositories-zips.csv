#load "./../common/nuget-restore.cake"



//---------------------------------------------------------------------------------------
Task("externals-private-sensitive")
    .Does
    (
        () =>
        {
            Information("    externals private ...");

            return;
        }
    );


RunTarget ("externals-private-sensitive");


public partial class Externals
{
    static partial void ExedcutePrivateSensitive()
    {
        context.Information("    externals private ...");

        return;
    }
}
//---------------------------------------------------------------------------------------
