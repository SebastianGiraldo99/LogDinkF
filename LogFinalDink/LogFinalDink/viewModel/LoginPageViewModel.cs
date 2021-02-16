using LogFinalDink.Services;
using LogFinalDink.Views;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LogFinalDink.viewModel
{
    class LoginPageViewModel
    {

        public ICommand CommandSignIn { get; set; }
        public ICommand BaseOnAppearing { get; set; }
        public LoginPageViewModel()
        {
            CommandSignIn = new Command(OnSignInClicked);
            BaseOnAppearing = new Command(baseOnAppearing);
        }

        async void OnSignInClicked()
        {
            AuthenticationResult result;

            try
            {
                result = await App.AuthenticationClient
                    .AcquireTokenInteractive(Constants.Scopes)
                    .WithPrompt(Prompt.ForceLogin)
                    .WithParentActivityOrWindow(App.UIParent)
                    .ExecuteAsync();

                Application.Current.MainPage = new LoginResultPage(result);
            }
            catch (MsalClientException)
            {

            }
        }
        protected  async void  baseOnAppearing()
        {
            try
            {
                // Look for existing account
                var accounts = await App.AuthenticationClient.GetAccountsAsync();

                if (accounts.Count() >= 1)
                {
                    AuthenticationResult result = await App.AuthenticationClient
                        .AcquireTokenSilent(Constants.Scopes, accounts.FirstOrDefault())
                        .ExecuteAsync();

                    Application.Current.MainPage = new LoginResultPage(result);
                   

                }
            }
            catch
            {
                // Do nothing - the user isn't logged in
            }
           
        }




    }
}
