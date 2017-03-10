using OneRewardsMvc.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace OneRewardsMvc.Tests
{
    
    
    /// <summary>
    ///This is a test class for RewardAccountTest and is intended
    ///to contain all RewardAccountTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RewardAccountTest
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
        ///A test for RewardAccount Constructor
        ///</summary>
        [TestMethod()]
        public void RewardAccountConstructorTest()
        {
            RewardAccount target = new RewardAccount();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for Company
        ///</summary>
        [TestMethod()]
        public void CompanyTest()
        {
            RewardAccount target = new RewardAccount(); 
            Company expected = null; 
            Company actual;
            target.Company = expected;
            actual = target.Company;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CompanyID
        ///</summary>
        [TestMethod()]
        public void CompanyIDTest()
        {
            RewardAccount target = new RewardAccount(); 
            int expected = 0; 
            int actual;
            target.CompanyID = expected;
            actual = target.CompanyID;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Points
        ///</summary>
        [TestMethod()]
        public void PointsTest()
        {
            RewardAccount target = new RewardAccount(); 
            Nullable<Decimal> expected = new Nullable<Decimal>(); 
            Nullable<Decimal> actual;
            target.Points = expected;
            actual = target.Points;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for RewardAccountID
        ///</summary>
        [TestMethod()]
        public void RewardAccountIDTest()
        {
            RewardAccount target = new RewardAccount(); 
            long expected = 0; 
            long actual;
            target.RewardAccountID = expected;
            actual = target.RewardAccountID;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for TotalPoints
        ///</summary>
        [TestMethod()]
        public void TotalPointsTest()
        {
            RewardAccount target = new RewardAccount(); 
            Nullable<Decimal> expected = new Nullable<Decimal>(); 
            Nullable<Decimal> actual;
            target.TotalPoints = expected;
            actual = target.TotalPoints;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for UserName
        ///</summary>

        [TestMethod()]
        public void UserNameTest()
        {
            RewardAccount target = new RewardAccount(); 
            string expected = string.Empty; 
            string actual;
            target.UserName = expected;
            actual = target.UserName;
            Assert.AreEqual(expected, actual);
        }
    }
}
