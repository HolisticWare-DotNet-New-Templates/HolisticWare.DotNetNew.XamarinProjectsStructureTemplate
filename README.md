# HolisticWare.DotNetNew.XamarinProjectsStructureTemplate


HolisticWare.DotNetNew.XamarinProjectsStructureTemplate

    # nuget restore invalid version errors
    dotnet new .
    # OK
    dotnet new ./
    

    nuget push \
        HolisticWare.DotNetNew.XamarinProjectsStructureTemplate.CSharp.2017.11.30.nupkg \
        -Source https://www.nuget.org/api/v2/package

    dotnet new -i Holisticware
    