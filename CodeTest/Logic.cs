using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest
{
    class Logic
    {

        public int calculateLicense(List<string> users, Dictionary<string, List<Computer>> userComputer)
        {
            int result = 0;
            foreach (var user in users)
            {
                //Get the computer count for each user 
                int ComputerCount = userComputer[user].Count();
                int LaptopCount = 0;
                foreach (var Computer in userComputer[user])
                {
                    if (Computer.ComputerType == "LAPTOP")
                    {
                        LaptopCount++;
                    }
                }

                result = result + (ComputerCount - ((LaptopCount / 2) == 0 ? 1 : (LaptopCount /2)));

            }
            return result;
        }

        public  void ReadAndInsertData(ref List<string> applicationUsers, ref Dictionary<string, List<Computer>> userComputers, string applicationID)
        {
            using (var reader = new StreamReader(File.OpenRead("C:\\Users\\anubh\\Downloads\\Code Test\\sample-small1.csv")))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values[2] == applicationID && values[2] != "" && values[2] != null)
                    {
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
    }
}
