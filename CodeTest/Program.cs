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

            List<string> applicationUsers = new List<string>();
            Dictionary<string, List<Computer>> userComputers = new Dictionary<string, List<Computer>>();
            ReadAndInsertData(ref applicationUsers,ref userComputers, "374");
            foreach (var item in userComputers)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine("the list is :");
                foreach (var values in item.Value)
                {
                    Console.WriteLine("ComputerID {0}, ComputerType {1}",values.ComputerID,values.ComputerType);
                }
            }

            Console.WriteLine("done 2");
            Console.ReadLine();
        }

        public static void ReadAndInsertData(ref List<string> applicationUsers,ref Dictionary<string, List<Computer>> userComputers, string applicationID)
        {
            using (var reader = new StreamReader(File.OpenRead("D:\\sample-small1.csv")))
            {
                while(!reader.EndOfStream)
               {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values[2] == applicationID && values[2] != "" && values[2] != null)
                    {
                        Console.WriteLine("ComputerID {0} : UserID {1} : ApplicationID {2} : ComputerType {3}", values[0].ToString(), values[1].ToString(), values[2].ToString(), values[3].ToString());
                        if (!applicationUsers.Contains(values[1]))
                        {
                            applicationUsers.Add(values[1]);
                        }

                        var computerInfo = new Computer
                        {
                            ComputerID = values[0],
                            ComputerType = values[3]
                        };

                        if (userComputers.ContainsKey(values[1]))
                        {
                            bool okToAdd = true;
                            // Checking if there are duplicate entries for the computer.
                            foreach (var computers in userComputers[values[1]].ToList())
                            {
                               if (computers.ComputerID == computerInfo.ComputerID && computers.ComputerType == computerInfo.ComputerType)
                                {
                                    okToAdd = false;

                                }
                                                            
                            }
                            if (okToAdd)
                            {
                                userComputers[values[1]].Add(computerInfo);
                            }
                            

                        }

                        else if (!userComputers.ContainsKey(values[1]))
                        {
                            userComputers.Add(values[1], new List<Computer> { computerInfo });
                        }
                    

                    }
                    
                }
            }
            Console.WriteLine("done");
            Console.ReadLine();

        }
    }
}
