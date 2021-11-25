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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }
    }
}