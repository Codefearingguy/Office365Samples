using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADAL.AuthenticationLibrary
{
    public class TokenHelper
    {
        public static async Task<string> GetAppOnlyAccessToken(string authority,
            string resourceUrl,
            string clientId,
            string clientSecret)
        {
            var authenticationContext = new AuthenticationContext(authority);
            // Config for OAuth client credentials 
            var clientCred = new ClientCredential(clientId, clientSecret);
            var authenticationResult = await authenticationContext.AcquireTokenAsync(resourceUrl, clientCred);
            //get access token
            return authenticationResult.AccessToken;
        }

        public static async Task<string> GetUserAccessToken(string authority,
            string resourceUrl,
            string clientId,
            Uri redirectUri)
        {
            AuthenticationContext authenticationContext = new AuthenticationContext(authority, false);
            AuthenticationResult userAuthnResult = await authenticationContext.AcquireTokenAsync(resourceUrl,
                clientId, redirectUri, new PlatformParameters(PromptBehavior.RefreshSession));
            return userAuthnResult.AccessToken;
        }
    }
}
