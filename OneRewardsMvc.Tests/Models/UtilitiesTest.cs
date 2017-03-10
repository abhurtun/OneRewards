using OneRewardsMvc.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web;
using System.Security.Principal;
using System.IO;
using System.Web.Hosting;

namespace OneRewardsMvc.Tests
{
    
    
    /// <summary>
    ///This is a test class for UtilitiesTest and is intended
    ///to contain all UtilitiesTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UtilitiesTest
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
        [TestInitialize()]
        public void MyTestInitialize()
        {
            // Setup the user account for testing.
            IIdentity identify = new System.Security.Principal.GenericIdentity("Unittest");
            IPrincipal currentUser = new System.Security.Principal.GenericPrincipal(identify, null);

            TextWriter tw = new StringWriter();
            HttpWorkerRequest wr = new SimpleWorkerRequest("/webapp", "c:\\inetpub\\wwwroot\\webapp\\", "default.aspx", "", tw);
            HttpContext.Current = new HttpContext(wr);

            System.Web.HttpContext.Current.User = currentUser;
        }
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Utilities Constructor
        ///</summary>
        [TestMethod()]
        public void UtilitiesConstructorTest()
        {
            Utilities target = new Utilities();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for ConvertImageFiletoBytes
        ///</summary>
        [TestMethod()]
        public void ConvertImageFiletoBytesTest()
        {
            Utilities target = new Utilities(); 
            string ImageFilePath = "c:\test\a.jpg"; 
            byte[] expected = null; 
            byte[] actual;
            actual = target.ConvertImageFiletoBytes(ImageFilePath);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for checkUser
        ///</summary>
        [TestMethod()]
        public void checkUserTest()
        {
            bool expected = true;
            bool actual;
            actual = Utilities.checkUser;
           Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for superUser
        ///</summary>
        [TestMethod()]
        public void superUserTest()
        {
            bool expected = false;
            bool actual;
            actual = Utilities.superUser;
            Assert.AreEqual(expected, actual);

        }
    }
}
