using OneRewardsWcfService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections.Generic;
using System.Configuration;

namespace OneRewardsTestProject
{
    
    
    /// <summary>
    ///This is a test class for IOneRewardsServiceTest and is intended
    ///to contain all IOneRewardsServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IOneRewardsServiceTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        internal virtual IOneRewardsService CreateIOneRewardsService()
        {
            // TODO: Instantiate an appropriate concrete class.
            IOneRewardsService target = new OneRewardsService();
            return target;
        }
        /// <summary>
        ///A test for connection Strings in config file
        ///</summary>
         [TestMethod()]
         public void VerifyAppDomainHasConfigurationSettings()
         {
             string value = ConfigurationManager.ConnectionStrings["OneRewardsEntities"].ConnectionString; ;
             Assert.IsFalse(String.IsNullOrEmpty(value), "No connection Strings found.");
         }

        /// <summary>
        ///A test for addRewardsAccount
        ///</summary>
        [TestMethod()]
        public void addRewardsAccountTest()
        {
            IOneRewardsService target = CreateIOneRewardsService(); 
            long accid = 1022; 
            int cid = 3; 
            string email = "atbneo@gmail.com"; 
            bool expected = true; 
            bool actual;
            target.removeRewardsAccount(accid, cid);
            actual = target.addRewardsAccount(accid, cid, email);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for addRewardsAccount
        ///</summary>
        [TestMethod()]
        public void addDuplicateRewardsAccountTest()
        {
            IOneRewardsService target = CreateIOneRewardsService();
            long accid = 1022;
            int cid = 3;
            string email = "atbneo@gmail.com";
            bool expected = false;
            bool actual;
            target.removeRewardsAccount(accid, cid);
            target.addRewardsAccount(accid, cid, email);
            actual = target.addRewardsAccount(accid, cid, email);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for autenticate unregistered user
        ///</summary>
        [TestMethod()]
        public void autenticateUnregisteredTest()
        {
            IOneRewardsService target = CreateIOneRewardsService(); 
            string Email = "z@hotmail.com"; 
            bool expected = false; 
            bool actual;
            actual = target.autenticate(Email);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for autenticate registered user
        ///</summary>
        [TestMethod()]
        public void autenticatRegisteredTest()
        {
            IOneRewardsService target = CreateIOneRewardsService();
            string Email = "atbneo@gmail.com";
            bool expected = true;
            bool actual;
            actual = target.autenticate(Email);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for getAPoints
        ///</summary>
        [TestMethod()]     

        public void getAPointsTest()
        {
            IOneRewardsService target = CreateIOneRewardsService(); 
            long accid = 1000; 
            int cid = 1; 
            double actual;
            actual = target.getAPoints(accid, cid);
            Assert.IsNotNull(actual);
         }

        /// <summary>
        ///A test for getAPoints for account that doesnot exsist
        ///</summary>
        [TestMethod()]

        public void getAPointsTest1()
        {
            IOneRewardsService target = CreateIOneRewardsService();
            long accid = 1500;
            int cid = 1;
            double expected = 0F;
            double actual;
            actual = target.getAPoints(accid, cid);
            Assert.AreEqual(actual , expected);
        }

        /// <summary>
        ///A test for getAllRewardsAccount non registered user
        ///</summary>
        [TestMethod()]
        public void getAllRewardsAccountTest()
        {
            IOneRewardsService target = CreateIOneRewardsService(); 
            string email = "zo@gmail.com"; 
            List<RewardAccount> expected = null; 
            List<RewardAccount> actual;
            actual = target.getAllRewardsAccount(email);
            Assert.AreEqual(expected, actual);
         }

        /// <summary>
        ///A test for getAllRewardsAccount registered user
        ///</summary>
        [TestMethod()]
        public void getAllRewardsAccountTest1()
        {
            IOneRewardsService target = CreateIOneRewardsService();
            string email = "atbneo@gmail.com";
            List<RewardAccount> expected = null;
            List<RewardAccount> actual;
            actual = target.getAllRewardsAccount(email);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for getCompanyLogo
        ///</summary>
        [TestMethod()]
        public void getCompanyLogoTest()
        {
            IOneRewardsService target = CreateIOneRewardsService(); 
            string name = "boots";           
            byte[] actual;
            actual = target.getCompanyLogo(name);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for getRewardsAccount
        ///</summary>
        [TestMethod()]
        public void getRewardsAccountTest()
        {
            IOneRewardsService target = CreateIOneRewardsService(); 
            long accid = 1000; 
            int cid = 1; 
            RewardAccount expected = null; 
            RewardAccount actual;
            actual = target.getRewardsAccount(accid, cid);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for getTPoints
        ///</summary>
        [TestMethod()]
        public void getTPointsTest()
        {
            IOneRewardsService target = CreateIOneRewardsService(); 
            long accid = 1000; 
            int cid = 1; 
            double expected = 0F; 
            double actual;
            actual = target.getTPoints(accid, cid);
            Assert.IsFalse(expected > actual);
        }

        /// <summary>
        ///A test for removeRewardsAccount
        ///</summary>
        [TestMethod()]
        public void removeRewardsAccountTest()
        {
            IOneRewardsService target = CreateIOneRewardsService(); 
            long accid = 1022; 
            int cid = 3; 
            bool expected = true; 
            bool actual;
            actual = target.addRewardsAccount(accid, cid, "atbneo@gmail.com");
            actual = target.removeRewardsAccount(accid, cid);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for removeRewardsAccount that doesnot exsit
        ///</summary>
        [TestMethod()]
        public void removeRewardsAccountTest1()
        {
            IOneRewardsService target = CreateIOneRewardsService();
            long accid = 1022;
            int cid = 3;
            bool expected = false;
            bool actual;
            actual = target.removeRewardsAccount(accid, cid);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for updatePoints add points
        ///</summary>
        [TestMethod()]
        public void updatePointsTest()
        {
            IOneRewardsService target = CreateIOneRewardsService(); 
            long accid = 1000; 
            int cid = 1; 
            double points = 30F; 
            bool expected = true; 
            bool actual;
            actual = target.updatePoints(accid, cid, points);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for updatePoints redeem
        ///</summary>
        [TestMethod()]
        public void updatePointsTest1()
        {
            IOneRewardsService target = CreateIOneRewardsService();
            long accid = 1000;
            int cid = 1;
            double points = -30F;
            bool expected = true;
            bool actual;
            actual = target.updatePoints(accid, cid, points);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for updatePoints try redeem
        ///more points that what account has
        ///</summary>
        [TestMethod()]
        public void updatePointsTest2()
        {
            IOneRewardsService target = CreateIOneRewardsService();
            long accid = 1000;
            int cid = 1;
            double points = -909930F;
            bool expected = false;
            bool actual;
            actual = target.updatePoints(accid, cid, points);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for getting all company names
        ///</summary>
        [TestMethod()]
        public void getCompanyNamesTest()
        {
            IOneRewardsService target = CreateIOneRewardsService();
            List<String> expected = null;
            List<String> actual;
            actual = target.getCompanyNames();
            Assert.AreNotEqual(expected, actual);
        }


        /// <summary>
        ///A test for getCompanyID
        ///</summary>
        [TestMethod()]
        public void getCompanyIDTest()
        {
            IOneRewardsService target = CreateIOneRewardsService();
            string cname = "Boots";
            int expected = 0;
            int actual;
            actual = target.getCompanyID(cname);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for getCompanyLogo
        ///</summary>
        [TestMethod()]
        public void getCompanyLogoIDTest()
        {
            IOneRewardsService target = CreateIOneRewardsService();
            int cid = 1;
            byte[] expected = null; 
            byte[] actual;
            actual = target.getCompanyLogoID(cid);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for getCompanys
        ///</summary>
        [TestMethod()]
        public void getCompanysTest()
        {
            IOneRewardsService target = CreateIOneRewardsService();
            List<Company> expected = null; 
            List<Company> actual;
            actual = target.getCompanys();
            Assert.AreNotEqual(expected, actual);
        }
    }
}
