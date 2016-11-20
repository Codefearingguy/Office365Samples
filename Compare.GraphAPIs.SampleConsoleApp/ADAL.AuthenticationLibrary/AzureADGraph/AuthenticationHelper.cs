using Microsoft.Azure.ActiveDirectory.GraphClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADAL.AuthenticationLibrary.AzureADGraph
{
    /// <summary>
    /// This is authentication provider for AAD Graph client.
    /// The only job this provider does is to generate the accesstoken and return it to the ActiveDirectoryClient.
    /// </summary>
    public class AuthenticationHelper
    {
        public static ActiveDirectoryClient GetActiveDirectoryClientAsApp()
        {
            ActiveDirectoryClient activeDirectoryClient = new ActiveDirectoryClient(Constants.serviceRoot,
                async () => await TokenHelper.GetAppOnlyAccessToken(AppModeConstants.Authority,
                Constants.ResourceUrl,
                AppModeConstants.ClientId,
                AppModeConstants.ClientSecret));
            return activeDirectoryClient;
        }
        public static ActiveDirectoryClient GetActiveDirectoryClientAsUser()
        {
            ActiveDirectoryClient activeDirectoryClient = new ActiveDirectoryClient(Constants.serviceRoot,
                async () => await TokenHelper.GetUserAccessToken(UserModeConstants.Authority,
                Constants.ResourceUrl,
                UserModeConstants.ClientId,
                UserModeConstants.RedirectUri));
            return activeDirectoryClient;
        }

    }
}
