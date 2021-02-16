using LogFinalDink.Views;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LogFinalDink.viewModel
{
    class LoginResultPageViewModel : NotificationObject

    {
        private AuthenticationResult authenticationResult;
        public ICommand ButtonSignOut { get; set; }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set {
                nombre = value;
                OnPropertyChanged();
            }
        }


        public LoginResultPageViewModel()
        {
           
            //var name = authenticationResult.Account.Username;
            ButtonSignOut = new Command(SignOutBtn_Clicked);
           

        }
        public LoginResultPageViewModel(AuthenticationResult authResult)
        {
            authenticationResult = authResult;
            //var name = authenticationResult.Account.Username;
            ButtonSignOut = new Command(SignOutBtn_Clicked);
            GetClains();

        }

        private string  GetClains()
        {
            var token = authenticationResult.IdToken;
            
            if (token != null)
            {
                string nombre;
                var handler = new JwtSecurityTokenHandler();
                var data = handler.ReadJwtToken(authenticationResult.IdToken);
                var claims = data.Claims.ToList();
                if (data != null)
                {
                    /// nombre = $"Welcome {data.Claims.FirstOrDefault(x => x.Type.Equals("given_name")).Value}";
                    Nombre = data.Claims.Where(x => x.Type.Equals("given_name")).ToList()[0].Value;
                    //this.issuer.Text = $"Issuer: { data.Claims.FirstOrDefault(x => x.Type.Equals("iss")).Value}";
                    //this.subject.Text = $"Subscription: {data.Claims.FirstOrDefault(x => x.Type.Equals("sub")).Value}";
                    //this.audience.Text = $"Audience: {data.Claims.FirstOrDefault(x => x.Type.Equals("aud")).Value}";
                    //this.email.Text = $"Email: {data.Claims.FirstOrDefault(x => x.Type.Equals("emails")).Value}";
                }
               
            }
            return nombre;
            
        }
        async void SignOutBtn_Clicked()
        {
            await App.AuthenticationClient.RemoveAsync(authenticationResult.Account);
            Application.Current.MainPage = new Login();
        }

        /*public string FirstOrDefault(JwtSecurityTokenHandler handler)
        {
            return handler
        }*/

    }
}
