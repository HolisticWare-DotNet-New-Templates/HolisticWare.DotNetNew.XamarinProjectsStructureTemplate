using System;
using Gtk;

namespace XamarinProjectsStructureTemplate.Sample.XamarinForms.Blank.GTK
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Gtk.Application.Init();
            Xamarin.Forms.Forms.Init();

            var app = new App();
            var window = new Xamarin.Forms.Platform.GTK.FormsWindow();
            window.LoadApplication(app);
            window.SetApplicationTitle("XamarinProjectsStructureTemplate.Sample.XamarinForms.Blank.GTK");
            window.Show();

            Gtk.Application.Run();
        }
    }
}
