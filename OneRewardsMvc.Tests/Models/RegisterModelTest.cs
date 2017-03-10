using OneRewardsMvc.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace OneRewardsMvc.Tests
{
    
    
    /// <summary>
    ///This is a test class for RegisterModelTest and is intended
    ///to contain all RegisterModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RegisterModelTest
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
        ///A test for RegisterModel Constructor
        ///</summary>
        [TestMethod()]
        public void RegisterModelConstructorTest()
        {
            RegisterModel target = new RegisterModel();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for ConfirmPassword
        ///</summary>
        [TestMethod()]
        public void ConfirmPasswordTest()
        {
            RegisterModel target = new RegisterModel(); 
            string expected = string.Empty; 
            string actual;
            target.ConfirmPassword = expected;
            actual = target.ConfirmPassword;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Email
        ///</summary>
        [TestMethod()]
        public void EmailTest()
        {
            RegisterModel target = new RegisterModel(); 
            string expected = string.Empty; 
            string actual;
            target.Email = expected;
            actual = target.Email;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Password
        ///</summary>
        [TestMethod()]
        public void PasswordTest()
        {
            RegisterModel target = new RegisterModel(); 
            string expected = string.Empty; 
            string actual;
            target.Password = expected;
            actual = target.Password;
            Assert.AreEqual(expected, actual);
         }

        /// <summary>
        ///A test for UserName
        ///</summary>
        [TestMethod()]
        public void UserNameTest()
        {
            RegisterModel target = new RegisterModel(); 
            string expected = string.Empty; 
            string actual;
            target.UserName = expected;
            actual = target.UserName;
            Assert.AreEqual(expected, actual);
        }
    }
}
