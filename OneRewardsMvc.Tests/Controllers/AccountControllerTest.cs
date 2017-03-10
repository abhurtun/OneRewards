using OneRewardsMvc.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using OneRewardsMvc.Models;
using System.Web.Security;
using System.Collections.Generic;

namespace OneRewardsMvc.Tests
{
    
    
    /// <summary>
    ///This is a test class for AccountControllerTest and is intended
    ///to contain all AccountControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AccountControllerTest
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
        ///A test for AccountController Constructor
        ///Ensure object can be created successfully.
        ///</summary>
         [TestMethod()]
        public void AccountControllerConstructorTest()
        {
            AccountController target = new AccountController();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for ChangePassword
        ///</summary>
        [TestMethod()]
        public void ChangePasswordTest()
        {
            AccountController target = new AccountController();
            var result = target.ChangePassword() as ViewResult;
            Assert.AreEqual("", result.ViewName);        


        }

        /// <summary>
        ///A test for ChangePassword
        ///</summary>
        [TestMethod()]
        public void ChangePasswordTest1()
        {
            AccountController target = new AccountController(); 
            ChangePasswordModel model = new ChangePasswordModel(); 
              var result = target.ChangePassword(model) as ViewResult;
              Assert.AreEqual(model, result.Model);

        }

        /// <summary>
        ///A test for ChangePasswordSuccess
        ///</summary>
        [TestMethod()]
        public void ChangePasswordSuccessTest()
        {
            AccountController target = new AccountController();
            var result = target.ChangePassword() as ViewResult;
            Assert.AreEqual("", result.ViewName); 

        }

   

        /// <summary>
        ///A test for Login
        ///</summary>
        [TestMethod()]
        public void LoginTest()
        {
            AccountController target = new AccountController(); 
            LoginModel model = new LoginModel(); 
            string returnUrl = string.Empty;
            var actual = target.Login(model, returnUrl) as ViewResult;
            Assert.AreEqual(false, actual.ViewData.ModelState.IsValid);

        }

        /// <summary>
        ///A test for Login
        ///</summary>
        [TestMethod()]
        public void LoginTest1()
        {
            AccountController target = new AccountController(); 
            string returnUrl = "http://www.google.com";
            var result = target.Login(returnUrl) as ViewResult;
            Assert.AreEqual("http://www.google.com", result.ViewBag.returnUrl); 

        }

        /// <summary>
        ///A test for Register
        ///</summary>
        


        [TestMethod()]
        public void RegisterTest()
        {
            AccountController target = new AccountController();
            var actual = target.Register() as ViewResult;
            Assert.AreEqual("", actual.ViewName); 

        }

        /// <summary>
        ///A test for Register
        ///</summary>
        


        [TestMethod()]
        public void RegisterTest1()
        {
            AccountController target = new AccountController(); 
            RegisterModel model = new RegisterModel();
            var actual = target.Register(model) as ViewResult;
            Assert.AreEqual(model, actual.Model);

        }
    }
}
