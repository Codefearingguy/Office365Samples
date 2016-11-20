using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADAL.AuthenticationLibrary
{

    class AppModeConstants
    {
        public static string ClientId
        {
            get
            {
                return "cd431e0f-c879-43e7-8619-87c2931baef7";
            }
        }

        public static string ClientSecret
        {
            get
            {
                return "Z76Rer+zDSPAoDsYn3beZ+9rVdgZhiE7l0crv50cwIg=";
            }
        }

        // The authority for authentication; combining the AADInstance
        // and the domain.
        public static string Authority
        {
            get
            {
                return $"{GlobalConstants.AuthString}/{GlobalConstants.Domain}/oauth2/token";
            }
        }
    }
}
