using System;
using System.Collections.Generic;
using System.Text;

namespace LogFinalDink.Services
{
    public static class Constants
    {
        public static readonly string TenantName = "Dinkco";
        public static readonly string TenantId = "Dinkco.onmicrosoft.com";

        public static readonly string ClientId = "e8edff27-c398-4cbc-a80c-8cde9cfc734f";
        public static readonly string SignInPolicy = "b2c_1_userlog";
       // public static readonly string PolicyPassword = "b2c_1_resetpass";
        public static readonly string IosKeychainSecurityGroups = "com.Dinkco.aabd2DinkCo"; // e.g com.contoso.aadb2cauthentication
        public static readonly string[] Scopes = new string[] { "openid", "offline_access" };
        public static readonly string AuthorityBase = $"https://{TenantName}.b2clogin.com/tfp/{TenantId}/";
        public static readonly string AuthoritySignIn = $"{AuthorityBase}{SignInPolicy}";
    }
}

