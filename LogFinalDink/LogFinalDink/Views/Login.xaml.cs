using LogFinalDink.Services;
using LogFinalDink.viewModel;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LogFinalDink.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            //try
            //{
            //    // Look for existing account
            //    var accounts = await App.AuthenticationClient.GetAccountsAsync();

            //    if (accounts.Count() >= 1)
            //    {
            //        AuthenticationResult result = await App.AuthenticationClient
            //            .AcquireTokenSilent(Constants.Scopes, accounts.FirstOrDefault())
            //            .ExecuteAsync();

            //        await Navigation.PushAsync(new LoginResultPage(result));
            //    }
            //}
            //catch
            //{
            //    // Do nothing - the user isn't logged in
            //}
            BindingContext = new LoginPageViewModel();
            base.OnAppearing();
        }


        //async void OnSignInClicked(object sender, EventArgs e)
        //{
        //    AuthenticationResult result;

        //    try
        //    {
        //        result = await App.AuthenticationClient
        //            .AcquireTokenInteractive(Constants.Scopes)
        //            .WithPrompt(Prompt.ForceLogin)
        //            .WithParentActivityOrWindow(App.UIParent)
        //            .ExecuteAsync();

        //        await Navigation.PushAsync(new LoginResultPage(result));
        //    }
        //    catch (MsalClientException)
        //    {

        //    }
        //}
    }
    
}