using AADGraphClientLibrary;
using MSGraphClientLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare.GraphAPIs.SampleConsoleApp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            RunFlow().Wait();
            Console.WriteLine("**Completed**\n Press any key to exit");
            Console.ReadKey();
        }

        private async static Task RunFlow()
        {
            Console.WriteLine("Press A to run AAD Graph API flow/Press any other key to run MS Graph API flow");
            var input = Console.ReadLine();
            if (input.Trim().ToUpper() == "A")
            {
                Console.WriteLine("Press 1 to run as App mode/Press any other key to run in user mode");
                input = Console.ReadLine();
                if (input.Trim().ToUpper() == "1")
                {
                    Console.WriteLine("Getting users using AAD graph api");
                    AADGraphClient graphClient = new AADGraphClient();
                    await graphClient.GetAllUsers();
                }
                else
                {
                    Console.WriteLine("Getting logged in user details using AAD graph api");
                    AADGraphClient graphClient = new AADGraphClient(true);
                    await graphClient.GetLoggedInUserDetails();
                }
            }
            else
            {
                Console.WriteLine("Press 1 to run as App mode/Press any other key to run in user mode");
                input = Console.ReadLine();
                if (input.Trim().ToUpper() == "1")
                {
                    Console.WriteLine("Getting users using MS graph api");
                    MSGraphClient graphClient = new MSGraphClient();
                    await graphClient.GetAllUsers();
                }
                else
                {
                    Console.WriteLine("Getting logged in user details using MS graph api");
                    MSGraphClient graphClient = new MSGraphClient(true);
                    await graphClient.GetLoggedInUserDetails();
                }
            }
        }
    }
}
