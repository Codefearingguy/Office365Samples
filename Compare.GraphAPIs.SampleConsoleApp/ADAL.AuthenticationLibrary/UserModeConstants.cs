using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADAL.AuthenticationLibrary
{
    internal class UserModeConstants
    {
        // The redirect URI specified in the Azure AD application
        public static Uri RedirectUri
        {
            get { return new Uri("http://localhost:55065/"); }
        }
        public static string ClientId
        {
            get
            {
                return "198d2a52-73a8-4db4-9789-85f3a7abd2bc";
            }
        }
        // The authority for authentication; combining the AADInstance
        // and the domain.
        public static string Authority
        {
            get
            {
                return $"{GlobalConstants.AuthString}/common/";
            }
        }
    }
}
