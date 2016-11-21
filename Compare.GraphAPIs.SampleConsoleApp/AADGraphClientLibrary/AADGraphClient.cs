using ADAL.AuthenticationLibrary.AzureADGraph;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AADGraphClientLibrary
{
    public class AADGraphClient
    {
        ActiveDirectoryClient adClient;
        public AADGraphClient(bool isUserMode = false)
        {
            if (isUserMode)
            {
                adClient = AuthenticationHelper.GetActiveDirectoryClientAsUser();
            }
            else
            {
                adClient = AuthenticationHelper.GetActiveDirectoryClientAsApp();
            }
        }
        public async Task GetAllUsers()
        {
            var userCollection = new List<IUser>();
            var users = await adClient.Users.ExecuteAsync();
            userCollection.AddRange(users.CurrentPage.ToList());
            while (users.MorePagesAvailable)
            {
                users = await users.GetNextPageAsync();
                userCollection.AddRange(users.CurrentPage.ToList());
            }
            foreach (var user in userCollection)
            {
                Console.WriteLine($"{user.DisplayName}");
            }
        }

        public async Task GetLoggedInUserDetails()
        {
            var loggedInUser = await adClient.Me.ExecuteAsync();
            Console.WriteLine($"Display Name:{loggedInUser.DisplayName}\nEmail:{loggedInUser.Mail}");
        }
    }
}
