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
        public static void Main(string[] args)
        {

            // Declaring the required valiables 
            // List to store the Users using that particular application
            // Dictionary for the Users to computer link.
            Relations rel = new Relations();
            rel.applicationUsers = new List<string>();
            rel.userComputers = new Dictionary<string, List<Computer>>();
            string applicationID = "374";

            string Path;
            if (args.Count() == 0)
            {
                Path = Directory.GetFiles(".", "*.csv")[0];
                Console.WriteLine(Path);
            }
            else
            {
                Path = args[0];
            }

            if(args.Count() == 2)
            {
                applicationID = args[1];
            }
            // Instantiatng the Logic core .
            Logic start = new Logic();

            // Reading Phase 
            Console.WriteLine("Reading data please wait ...");
            start.ReadAndInsertData( rel.applicationUsers, rel.userComputers, applicationID, Path);

            // Calulate the Licenses required. 
            Console.WriteLine("Calculating licensing position ... ");
            Console.WriteLine("");
            Console.WriteLine("");

            #if DEBUG 
                // Debug info if required for the calculations .
                Console.WriteLine("Reading done displaying meaningful data :- ");
            #endif

            int answer = start.calculateLicense(rel.applicationUsers, rel.userComputers);
            Console.WriteLine("************************");
            Console.WriteLine("The required License count is : {0}", answer);
            Console.WriteLine("Press enter to quit.");
            Console.ReadLine();

        }

    }
}
