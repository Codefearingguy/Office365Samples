using Microsoft.Graph;
/// <summary>
/// This is an AuthenticationProvider implementation for MS Graph Client.
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ADAL.AuthenticationLibrary.MicrosoftGraph
{
    /// <summary>
    /// This class implements authentication for running MS Graph clients as  Application context and not user context.
    /// </summary>
    public class AppOnlyModeAuthenticationProvider : IAuthenticationProvider
    {
        public async Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            var appOnlyAccessToken = await TokenHelper.GetAppOnlyAccessToken(AppModeConstants.Authority,
                Constants.ResourceUrl,
                AppModeConstants.ClientId,
                AppModeConstants.ClientSecret);
            //add acccess token into request headers
            request.Headers.Add("Authorization", "Bearer " + appOnlyAccessToken);
        }
    }

    /// <summary>
    /// This class implements authentication for running MS Graph clients as  user context.
    /// Here user will need to provide consent to application to use resources.
    /// </summary>
    public class UserModeAuthenticationProvider : IAuthenticationProvider
    {
        public async Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            var userAccessToken = await TokenHelper.GetUserAccessToken(UserModeConstants.Authority,
                Constants.ResourceUrl,
                UserModeConstants.ClientId,
                UserModeConstants.RedirectUri);
            //add acccess token into request headers
            request.Headers.Add("Authorization", "Bearer " + userAccessToken);
        }
    }
}
