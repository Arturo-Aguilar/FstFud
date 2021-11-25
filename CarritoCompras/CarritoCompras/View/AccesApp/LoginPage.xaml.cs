using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarritoCompras.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarritoCompras.View.AccesApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new RegisterPage());
            Application.Current.MainPage = new RegisterPage();
        }
    }
}