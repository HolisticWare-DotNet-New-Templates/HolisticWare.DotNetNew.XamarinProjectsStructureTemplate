using AppKit;

namespace XamarinProjectsStructureTemplate.Sample.XamarinForms.Blank
{
    static class MainClass
    {
        static void Main(string[] args)
        {
            NSApplication.Init();
            NSApplication.SharedApplication.Delegate = new AppDelegate();
            NSApplication.Main(args);

            return;
        }
    }
}
