using System;
using System.Collections.Generic;
using System.Text;

using Firebase.Auth;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

using CarritoCompras.Service;
using CarritoCompras.Modelo;
using CarritoCompras.View;
using Microsoft.AppCenter.Crashes;

namespace CarritoCompras.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        #region Attributes
        public string email;
        public string password;
        public string name;
        public string age;
        /*public bool isRunning;
        public bool isVisible;
        public bool isEnabled;*/
        #endregion

        #region Properties
        public string EmailTxt
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string PasswordTxt
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public string NameTxt
        {
            get { return this.name; }
            set { SetValue(ref this.name, value); }
        }

        public string AgeTxt
        {
            get { return this.age; }
            set { SetValue(ref this.age, value); }
        }

        /*public bool IsVisibleTxt
        {
            get { return this.isVisible; }
            set { SetValue(ref this.isVisible, value); }
        }

        public bool IsEnabledTxt
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        public bool IsRunningTxt
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }*/

        #endregion

        #region Commands
        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(RegisterMethod);
            }
        }
        #endregion

        #region Methods
        #region Methods
        private async void RegisterMethod()
        {
            if (string.IsNullOrEmpty(this.email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes introducir un correo.",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes introducir una contraseña.",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.name))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes introducir un nombre.",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.age))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes introducir una edad.",
                    "Aceptar");
                return;
            }

            string WebAPIkey = "AIzaSyCjurVhfNPT9owUd9SjlJnKfpgoAIbkaTA";
            //string WebAPIkey = "AIzaSyCIApDaPdsmOe_JzifrNRCfplX_YxxsKBo";
            try
            {
                var person = new PersonModel
                {
                    NameField = name,
                    AgeField = int.Parse(age),
                };
                await firebaseHelper.AddPerson(person);

                //this.IsRefreshing = true;

                await Task.Delay(1000);

                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(EmailTxt.ToString(), PasswordTxt.ToString());
                string gettoken = auth.FirebaseToken;

                await Application.Current.MainPage.DisplayAlert("Exitosamente", "Bienvenido " + name.ToString() + " a tu aplicación", "Ok");
                /*this.IsRunningTxt = false;
                this.IsVisibleTxt = false;
                this.IsEnabledTxt = true;*/
                //await Application.Current.MainPage.Navigation.PushAsync(new PageInicio());
                Application.Current.MainPage = new PageInicio();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                await Application.Current.MainPage.DisplayAlert("¡Oops!", "Algo salio mal", "Aceptar");
            }
        }

        #endregion
        #endregion

        #region Constructor
        public RegisterViewModel()
        {
            //IsEnabledTxt = true;
        }
        #endregion
    }
}
