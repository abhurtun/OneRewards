using OneRewardsMvc.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace OneRewardsMvc.Tests
{
    
    
    /// <summary>
    ///This is a test class for CompanyTest and is intended
    ///to contain all CompanyTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CompanyTest
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


        /// <summary>
        ///A test for Company Constructor
        ///</summary>
        [TestMethod()]
        public void CompanyConstructorTest()
        {
            Company target = new Company();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for CompanyID
        ///</summary>
        [TestMethod()]
        public void CompanyIDTest()
        {
            Company target = new Company(); 
            int expected = 0; 
            int actual;
            target.CompanyID = expected;
            actual = target.CompanyID;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CompanyLogo
        ///</summary>
        [TestMethod()]
        public void CompanyLogoTest()
        {
            Company target = new Company(); 
            byte[] expected = null; 
            byte[] actual;
            target.CompanyLogo = expected;
            actual = target.CompanyLogo;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CompanyName
        ///</summary>
        [TestMethod()]
        public void CompanyNameTest()
        {
            Company target = new Company(); 
            string expected = string.Empty; 
            string actual;
            target.CompanyName = expected;
            actual = target.CompanyName;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CompanyRewardsLink
        ///</summary>
        [TestMethod()]
        public void CompanyRewardsLinkTest()
        {
            Company target = new Company(); 
            string expected = string.Empty; 
            string actual;
            target.CompanyRewardsLink = expected;
            actual = target.CompanyRewardsLink;
            Assert.AreEqual(expected, actual);
        }
    }
}
