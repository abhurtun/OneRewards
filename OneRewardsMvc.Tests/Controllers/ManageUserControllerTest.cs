﻿using OneRewardsMvc.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;

namespace OneRewardsMvc.Tests
{
    
    
    /// <summary>
    ///This is a test class for ManageUserControllerTest and is intended
    ///to contain all ManageUserControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ManageUserControllerTest
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
        ///A test for ManageUserController Constructor
        ///</summary>
        


        [TestMethod()]
        public void ManageUserControllerConstructorTest()
        {
            ManageUserController target = new ManageUserController();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for Create
        ///</summary>
        


        [TestMethod()]
        public void CreateTest()
        {
            ManageUserController target = new ManageUserController(); 
            string User = "test"; 
            string role = "User"; 
            var actual = target.Create(User, role) as ViewResult;
            Assert.IsNull(actual);

        }

        /// <summary>
        ///A test for Create
        ///</summary>
        


        [TestMethod()]
        public void CreateTest1()
        {
            ManageUserController target = new ManageUserController(); 
            var actual = target.Create() as ViewResult;
            Assert.AreEqual("", actual.ViewName);

        }
        
    }
}
