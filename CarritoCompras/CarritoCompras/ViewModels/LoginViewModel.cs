using System;
using System.Collections.Generic;
using System.Text;

using CarritoCompras.View;
using CarritoCompras.Modelo;
using CarritoCompras.Service;

using Firebase.Auth;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Microsoft.AppCenter.Analytics;

namespace CarritoCompras.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Attribute
        public string email;
        public string password;
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

        /*public bool IsRunningTxt
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }


        public bool IsVisibleTxt
        {
            get { return this.isVisible; }
            set { SetValue(ref this.isVisible, value); }
        }

        public bool IsEnabledTxt
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }*/

        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(LoginMethod);
            }
        }
        #endregion

        #region Methods


        public async void LoginMethod()
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

            //string WebAPIkey = "AIzaSyCjurVhfNPT9owUd9SjlJnKfpgoAIbkaTA";
            //string WebAPIkey = "AIzaSyCIApDaPdsmOe_JzifrNRCfplX_YxxsKBo";
            UserAuthentication oUsuario = new UserAuthentication()
            {
                email = EmailTxt.ToString(),
                password = PasswordTxt.ToString(),
                returnSecureToken = true
            };

            //var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                /*var auth = await authProvider.SignInWithEmailAndPasswordAsync(EmailTxt.ToString(), PasswordTxt.ToString());
                var content = await auth.GetFreshAuthAsync();
                var serializedcontnet = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);*/

                bool respuesta = await ApiServiceAuthentication.Login(oUsuario);
                if (respuesta)
                {
                    //Application.Current.MainPage = new NavigationPage(new MasterPage());
                    //Application.Current.MainPage = new MasterPage();
                    Analytics.TrackEvent("Inicio de sesion");
                    Application.Current.MainPage = new PageInicio();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Oops", "Usuario no encontrado", "OK");
                }

                //Application.Current.MainPage = new PageInicio();
                //Puede navegar al tener autorizacion
                //await Application.Current.MainPage.Navigation.PushAsync(new ContainerTabbedPags());

                //await Application.Current.MainPage.Navigation.PushAsync(new MainPage());

                /*this.IsRunningTxt = false;
                this.IsVisibleTxt = false;
                this.IsEnabledTxt = true;*/

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Mensaje", "Debe completar todos los campos", "OK");

                /*this.IsRunningTxt = false;
                this.IsVisibleTxt = false;
                this.IsEnabledTxt = true;*/
            }

        }
        #endregion

        #region Constructor
        /*public LoginViewModel()
        {
            this.IsEnabledTxt = true;
        }*/
        #endregion
    }
}
