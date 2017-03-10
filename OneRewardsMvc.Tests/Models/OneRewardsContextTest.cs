using OneRewardsMvc.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Data.Entity;

namespace OneRewardsMvc.Tests
{
    
    
    /// <summary>
    ///This is a test class for OneRewardsContextTest and is intended
    ///to contain all OneRewardsContextTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OneRewardsContextTest
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
        ///A test for OneRewardsContext Constructor
        ///</summary>
        [TestMethod()]
        public void OneRewardsContextConstructorTest()
        {
            OneRewardsContext target = new OneRewardsContext();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for Companys
        ///</summary>
        [TestMethod()]
        public void CompanysTest()
        {
            OneRewardsContext target = new OneRewardsContext(); 
            DbSet<Company> expected = null; 
            DbSet<Company> actual;
            target.Companys = expected;
            actual = target.Companys;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for RewardAccounts
        ///</summary>
        [TestMethod()]
        public void RewardAccountsTest()
        {
            OneRewardsContext target = new OneRewardsContext(); 
            DbSet<RewardAccount> expected = null; 
            DbSet<RewardAccount> actual;
            target.RewardAccounts = expected;
            actual = target.RewardAccounts;
            Assert.AreEqual(expected, actual);

        }
    }
}
