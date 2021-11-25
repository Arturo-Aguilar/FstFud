using CarritoCompras.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using CarritoCompras.View.AccesApp;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CarritoCompras
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new PageLogin();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            AppCenter.Start("android=690b6ceb-1542-4169-887d-dd32aa8683af;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here}",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
