using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeTest;
using System.Collections.Generic;
using System.IO;
using System;

namespace CodeTestTests
{
    [TestClass]
    public class CodeTests
    {
        [TestMethod]
        public void ReadAndInsertDataTest()
        {
            //Arrange

            List<string> applicationUsers = new List<string>();
            Dictionary<string, List<Computer>> userComputers = new Dictionary<string, List<Computer>>();
            Logic TestRead = new Logic();

            //Act 

            TestRead.ReadAndInsertData(applicationUsers, userComputers, "374", Directory.GetFiles(".", "*1.csv")[0]);

            //Assert


            Assert.AreEqual(3, applicationUsers.Count);// Check to see if there are 3 users .
            Assert.AreEqual(3,userComputers.Count);// Check to see if there are only 3 objects in the dictionary.
            Assert.AreEqual(1, userComputers["1091"].Count);// Check to see of there are no duplicates.
            Assert.AreEqual(3, userComputers["1"].Count);// Checking the computer count for the users to see if they are correct with duplicates.
            Assert.AreEqual(2, userComputers["2"].Count);//Checking with normal user no dupes.


        }

        [TestMethod]
        public void testCalculateLicensePosition()
        {
            //Arrange

            List<string> applicationUsers = new List<string>();
            Dictionary<string, List<Computer>> userComputers = new Dictionary<string, List<Computer>>();
            //For testing with different dataset
            List<string> applicationUsers1 = new List<string>();
            Dictionary<string, List<Computer>> userComputers1 = new Dictionary<string, List<Computer>>();
            Logic TestLic = new Logic();

            //Act 

            TestLic.ReadAndInsertData(applicationUsers, userComputers, "374", Directory.GetFiles(".", "*1.csv")[0]);
            TestLic.ReadAndInsertData(applicationUsers1, userComputers1, "374", Directory.GetFiles(".", "*l.csv")[0]);
            int LicenseCounts = TestLic.calculateLicense(applicationUsers, userComputers);
            int LicenseCounts1 = TestLic.calculateLicense(applicationUsers1, userComputers1);


            //Assert

            Assert.AreEqual(5, LicenseCounts);// Checking to see of the logic correctly returns the License counts.
            Assert.AreEqual(190, LicenseCounts1);// Chacking with a second set of data. 

        }
    }
}
