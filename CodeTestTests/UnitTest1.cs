using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeTest;
using System.Collections.Generic;
using System.IO;

namespace CodeTestTests
{
    [TestClass]
    public class UnitTest1
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
            Logic TestLic = new Logic();

            //Act 

            TestLic.ReadAndInsertData(applicationUsers, userComputers, "374", Directory.GetFiles(".", "*1.csv")[0]);
            int answer = TestLic.calculateLicense(applicationUsers, userComputers);


            //Assert

            Assert.AreEqual(5, answer);

        }
    }
}
