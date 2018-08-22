using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest
{
    class Program
    {
        static void Main(string[] args)
        {

            // Declaring the required valiables 
            // List to store the Users using that particular application
            // Dictionary for the Users to computer link.

            List<string> applicationUsers = new List<string>();
            Dictionary<string, List<Computer>> userComputers = new Dictionary<string, List<Computer>>();

            // Instantiatng the Logic core .
            Logic start = new Logic();

            // Reading Phase 
            Console.WriteLine("Reading data please wait ...");
            start.ReadAndInsertData(ref applicationUsers,ref userComputers, "374");

            // Debug info if required for the calculations .
            Console.WriteLine("Reading done displaying meaningful data :- ");
            foreach (var user in userComputers)
            {
                Console.WriteLine("UserID is : {0}" , user.Key);
                Console.WriteLine("the Computer list is :");
                foreach (var Computer in user.Value)
                {
                    Console.WriteLine("ComputerID {0}, ComputerType {1}",Computer.ComputerID,Computer.ComputerType);
                }
            }

            // Calulate the Licenses required. 
            Console.WriteLine("Calculating licensing position ... ");
            Console.WriteLine("");
            Console.WriteLine("");
            int answer = start.calculateLicense(applicationUsers, userComputers);
            Console.WriteLine("************************");
            Console.WriteLine("The required License count is : {0}", answer);
            Console.ReadLine();
        }

    }
}
