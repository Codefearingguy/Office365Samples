using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADAL.AuthenticationLibrary.AzureADGraph
{
    public class Constants
    {
        public static string ResourceUrl
        {
            get
            {
                return "https://graph.windows.net";
            }
        }

        private static Uri servicePointUri
        {
            get
            {
                return new Uri(Constants.ResourceUrl);
            }
        }
        public static Uri serviceRoot
        {
            get
            {
                return new Uri(servicePointUri, GlobalConstants.TenantId);
            }
        }
    }
}
