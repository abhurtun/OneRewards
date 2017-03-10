using OneRewardsMvc.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace OneRewardsMvc.Tests
{
    
    
    /// <summary>
    ///This is a test class for LoginModelTest and is intended
    ///to contain all LoginModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LoginModelTest
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
        ///A test for LoginModel Constructor
        ///</summary>
        [TestMethod()]
        public void LoginModelConstructorTest()
        {
            LoginModel target = new LoginModel();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for Password
        ///</summary>
        [TestMethod()]
        public void PasswordTest()
        {
            LoginModel target = new LoginModel(); 
            string expected = string.Empty; 
            string actual;
            target.Password = expected;
            actual = target.Password;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for RememberMe
        ///</summary>
        [TestMethod()]
        public void RememberMeTest()
        {
            LoginModel target = new LoginModel(); 
            bool expected = false; 
            bool actual;
            target.RememberMe = expected;
            actual = target.RememberMe;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for UserName
        ///</summary>
        [TestMethod()]
        public void UserNameTest()
        {
            LoginModel target = new LoginModel(); 
            string expected = string.Empty; 
            string actual;
            target.UserName = expected;
            actual = target.UserName;
            Assert.AreEqual(expected, actual);
        }
    }
}
