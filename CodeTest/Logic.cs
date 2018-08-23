using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest
{
   public  class Logic
    {

        // Main Licensing logic exists here .

        public int calculateLicense(List<string> users, Dictionary<string, List<Computer>> userComputer)
        {
            int result = 0;
            foreach (var user in users)
            {
                #if DEBUG
                    Console.WriteLine("The User ID is {0}", user);
                    Console.WriteLine("The List of computers for this user is :");
                #endif
                //Get the computer count for each user 
                int ComputerCount = userComputer[user].Count();
                int LaptopCount = 0;
                int DesktopCount = 0;
                int PartCount = 0;
                foreach (var Computer in userComputer[user])
                {
                    #if DEBUG
                        Console.WriteLine("ComputerID {0}, ComputerType {1}", Computer.ComputerID, Computer.ComputerType);
                    #endif
                    if (Computer.ComputerType == "LAPTOP")
                    {
                        LaptopCount++;
                    }
                    if (Computer.ComputerType == "DESKTOP")
                    {
                        DesktopCount++;
                    }
                }
                if(DesktopCount >= LaptopCount)
                {
                    PartCount = LaptopCount + (DesktopCount - LaptopCount);
                }
                else
                {
                    PartCount = (((LaptopCount - DesktopCount) % 2 == 0) ? ((LaptopCount - DesktopCount) / 2) : (((LaptopCount - DesktopCount) / 2) + 1)) + DesktopCount;
                }
                #if DEBUG
                    Console.WriteLine("Consumption for this User ID:{0} is:{1}",user, PartCount);
                    Console.WriteLine("");
                #endif

                result = result + PartCount;

            }
            return result;
        }

        public  void ReadAndInsertData( List<string> applicationUsers,  Dictionary<string, List<Computer>> userComputers, string applicationID, string Path)
        {
            using (var reader = new StreamReader(File.OpenRead(Path)))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values[2] == applicationID && values[2] != "" && values[2] != null && values[0] != "" && values[0] != null && values[3] != "" && values[3] != null)
                    {
                        //Uncomment for debug output.
                        //  Console.WriteLine("ComputerID {0} : UserID {1} : ApplicationID {2} : ComputerType {3}", values[0].ToString(), values[1].ToString(), values[2].ToString(), values[3].ToString());
                        if (!applicationUsers.Contains(values[1]))
                        {
                            applicationUsers.Add(values[1].ToUpper());
                        }

                        var computerInfo = new Computer
                        {
                            ComputerID = values[0].ToUpper(),
                            ComputerType = values[3].ToUpper()
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


        }

        //generic method can be 
        public int calculateLicenseGeneric(List<string> users, Dictionary<string, List<Computer>> userComputer, int noComputersAllowed)
        {
            int result = 0;
            foreach (var user in users)
            {
#if DEBUG
                Console.WriteLine("The User ID is {0}", user);
                Console.WriteLine("The List of computers for this user is :");
#endif
                //Get the computer count for each user 
                int ComputerCount = userComputer[user].Count();
                int LaptopCount = 0;
                int DesktopCount = 0;
                int PartCount = 0;
                foreach (var Computer in userComputer[user])
                {
#if DEBUG
                    Console.WriteLine("ComputerID {0}, ComputerType {1}", Computer.ComputerID, Computer.ComputerType);
#endif
                    if (Computer.ComputerType == "LAPTOP")
                    {
                        LaptopCount++;
                    }
                    if (Computer.ComputerType == "DESKTOP")
                    {
                        DesktopCount++;
                    }
                }
                if (DesktopCount >= (LaptopCount * noComputersAllowed))
                {
                    PartCount = LaptopCount + (DesktopCount - (LaptopCount * noComputersAllowed));
                }

                if(DesktopCount < (LaptopCount * noComputersAllowed))
                {
                    if ((DesktopCount / noComputersAllowed) > 0)
                    {
                        PartCount = PartCount + (DesktopCount / noComputersAllowed);
                        int remainingComputer = (((DesktopCount + LaptopCount) - ((noComputersAllowed + 1) * (DesktopCount / noComputersAllowed))));
                        PartCount = PartCount + (remainingComputer  % (noComputersAllowed + 1) == 0 ? (remainingComputer / (noComputersAllowed + 1)) : (remainingComputer / (noComputersAllowed +1 )) + 1);
                    }
                    else
                    {
                        PartCount = (DesktopCount + LaptopCount) % (noComputersAllowed + 1) == 0 ? (DesktopCount + LaptopCount) / (noComputersAllowed + 1) : ((DesktopCount + LaptopCount) / (noComputersAllowed + 1) + 1);
                    }

                }

                    

#if DEBUG
                Console.WriteLine("Consumption for this User ID:{0} is:{1}", user, PartCount);
                Console.WriteLine("");
#endif

                result = result + PartCount;

            }
            return result;
        }
    }
}
