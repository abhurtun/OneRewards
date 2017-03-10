using OneRewardsMvc.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace OneRewardsMvc.Tests
{
    
    
    /// <summary>
    ///This is a test class for ChangePasswordModelTest and is intended
    ///to contain all ChangePasswordModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ChangePasswordModelTest
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
        ///A test for ChangePasswordModel Constructor
        ///</summary>
        [TestMethod()]
        public void ChangePasswordModelConstructorTest()
        {
            ChangePasswordModel target = new ChangePasswordModel();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for ConfirmPassword
        ///</summary>
        [TestMethod()]
        public void ConfirmPasswordTest()
        {
            ChangePasswordModel target = new ChangePasswordModel(); 
            string expected = string.Empty; 
            string actual;
            target.ConfirmPassword = expected;
            actual = target.ConfirmPassword;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for NewPassword
        ///</summary>
        [TestMethod()]
        public void NewPasswordTest()
        {
            ChangePasswordModel target = new ChangePasswordModel(); 
            string expected = string.Empty; 
            string actual;
            target.NewPassword = expected;
            actual = target.NewPassword;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for OldPassword
        ///</summary>
        [TestMethod()]
        public void OldPasswordTest()
        {
            ChangePasswordModel target = new ChangePasswordModel(); 
            string expected = string.Empty; 
            string actual;
            target.OldPassword = expected;
            actual = target.OldPassword;
            Assert.AreEqual(expected, actual);
        }
    }
}
