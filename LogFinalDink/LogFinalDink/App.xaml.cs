using LogFinalDink.Services;
using LogFinalDink.Views;
using Microsoft.Identity.Client;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LogFinalDink
{
    public partial class App : Application
    {
        public static IPublicClientApplication AuthenticationClient { get; private set; }

        public static object UIParent { get; set; } = null;
        public App()
        {
            InitializeComponent();

            AuthenticationClient = PublicClientApplicationBuilder.Create(Constants.ClientId)
               .WithIosKeychainSecurityGroup(Constants.IosKeychainSecurityGroups)
               .WithB2CAuthority(Constants.AuthoritySignIn)
               .WithRedirectUri($"msal{Constants.ClientId}://auth")
               .Build();


            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
