using ADAL.AuthenticationLibrary.MicrosoftGraph;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSGraphClientLibrary
{
    public class MSGraphClient
    {
        GraphServiceClient graphClient;
        public MSGraphClient(bool isUserMode = false)
        {
            if (isUserMode)
            {
                graphClient = new GraphServiceClient(new UserModeAuthenticationProvider());
            }
            else
            {
                graphClient = new GraphServiceClient(new AppOnlyModeAuthenticationProvider());
            }
        }
        public async Task GetAllUsers()
        {
            var userCollection = new List<User>();
            var users = await graphClient.Users.Request().GetAsync();
            userCollection.AddRange(users);
            while (users.NextPageRequest != null)
            {
                users = await users.NextPageRequest.GetAsync();
                userCollection.AddRange(users);
            }
            foreach (var user in userCollection)
            {
                Console.WriteLine($"{user.DisplayName}");
            }
        }
        public async Task GetLoggedInUserDetails()
        {
            var loggedInUser = await graphClient.Me.Request().GetAsync();
            Console.WriteLine($"Display Name:{loggedInUser.DisplayName}\nEmail:{loggedInUser.Mail}");
        }
    }
}
