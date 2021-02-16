using Microsoft.Identity.Client;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LogFinalDink.viewModel;

namespace LogFinalDink.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginResultPage : ContentPage
    {
        private AuthenticationResult authenticationResult;

        public LoginResultPage(AuthenticationResult authResult)
        {
            authenticationResult = authResult;
            //var name = authenticationResult.Account.Username;
            
            InitializeComponent();
        }

       protected override void OnAppearing()
        {
            BindingContext = new LoginResultPageViewModel(authenticationResult);
            base.OnAppearing();
            
        }

        //private void GetClaims()
        //{
        //    var token = authenticationResult.IdToken;
        //    if (token != null)
        //    {
        //        var handler = new JwtSecurityTokenHandler();
        //        var data = handler.ReadJwtToken(authenticationResult.IdToken);
        //        var claims = data.Claims.ToList();
        //        if (data != null)
        //        {
        //            this.welcome.Text = $"Welcome {data.Claims.FirstOrDefault(x => x.Type.Equals("given_name")).Value}";
        //            this.issuer.Text = $"Issuer: { data.Claims.FirstOrDefault(x => x.Type.Equals("iss")).Value}";
        //            this.subject.Text = $"Subscription: {data.Claims.FirstOrDefault(x => x.Type.Equals("sub")).Value}";
        //            this.audience.Text = $"Audience: {data.Claims.FirstOrDefault(x => x.Type.Equals("aud")).Value}";
        //            this.email.Text = $"Email: {data.Claims.FirstOrDefault(x => x.Type.Equals("emails")).Value}";
        //        }
        //    }
        //}

        //async void SignOutBtn_Clicked(System.Object sender, System.EventArgs e)
        //{
        //    await App.AuthenticationClient.RemoveAsync(authenticationResult.Account);
        //    await Navigation.PushAsync(new Login());
        //}
    }
}