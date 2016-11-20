using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADAL.AuthenticationLibrary
{
    public class GlobalConstants
    {
        /// <summary>
        /// AAD Instance or login page
        /// </summary>
        public static string AuthString
        {
            //get { return "https://login.microsoftonline.com/"; }
            get { return "https://login.windows.net"; }
        }

        // The Office 365 domain (e.g. contoso.microsoft.com)
        public static string Domain
        {
            get { return "sp2013kitchen.onmicrosoft.com"; }
        }


        public static string TenantId
        {
            get
            {
                return "94ab7492-e39e-4298-8635-b1a3a4221f6b";
            }
        }
    }
}
