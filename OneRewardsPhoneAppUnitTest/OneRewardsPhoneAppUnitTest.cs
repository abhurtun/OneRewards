using System;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO.IsolatedStorage;
using System.IO;
using System.Text;
using OneRewardsPhoneApp;

namespace OneRewardsPhoneAppUnitTest
{
    [TestClass()]
    public class OneRewardsPhoneAppUnitTest : SilverlightTest
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

        [TestMethod()]
        [Tag("Dummy Test")]
        [Description("Dummy Test")]
        public void AlwaysTrue()
        {
            Assert.IsTrue(true, "this method always pass");
        }

        [TestMethod()]
        [Tag("LoginPage")]
        [Description("Unit Test LoginPage")]
        public void OneRewardsPhoneAppLoginPageTest()
        {
            OneRewardsPhoneApp.Views.LoginPage LoginPage = new OneRewardsPhoneApp.Views.LoginPage();
            Assert.IsNotNull(LoginPage);
            Assert.AreNotEqual(LoginPage.Title, "");
            Assert.IsTrue(LoginPage.IsEnabled);
        }

        [TestMethod()]
        [Tag("AddAccount")]
        [Description("Unit Test AddAccount")]
        public void OneRewardsPhoneAppAddAccountTest()
        {
            OneRewardsPhoneApp.Views.AddAccount addacc = new OneRewardsPhoneApp.Views.AddAccount();
            Assert.IsNotNull(addacc);
            Assert.AreNotEqual(addacc.Title, "");
            Assert.IsTrue(addacc.IsEnabled);
        }

        [TestMethod()]
        [Tag("AccountList")]
        [Description("Unit Test AccountList")]
        public void OneRewardsPhoneAppAccountListTest()
        {
            //set the account file
            WritePinToFile();

            OneRewardsPhoneApp.Views.AccountList acclist = new OneRewardsPhoneApp.Views.AccountList();
            Assert.IsNotNull(acclist);
            Assert.AreNotEqual(acclist.Title, "");
            Assert.IsTrue(acclist.IsEnabled);
        }


        [TestMethod()]
        [Tag("MainMenuPage")]
        [Description("Unit Test MainMenuPage")]
        public void OneRewardsPhoneAppMainMenuPageTest()
        {
            OneRewardsPhoneApp.Views.MainMenuPage MainMenuPage = new OneRewardsPhoneApp.Views.MainMenuPage();
            Assert.IsNotNull(MainMenuPage);
            Assert.AreNotEqual(MainMenuPage.Title, "");
            Assert.IsTrue(MainMenuPage.IsEnabled);
        }

        [TestMethod()]
        [Tag("PictureConverter")]
        [Description("Unit Test PictureConverter")]
        [ExpectedException(typeof(NullReferenceException))]
        public void OneRewardsPhoneAppPictureConverterTest()
        {
            OneRewardsPhoneApp.Views.PictureConverter PictureConverter = new OneRewardsPhoneApp.Views.PictureConverter();
            Assert.IsNotNull(PictureConverter);
            Assert.IsNotNull(PictureConverter.Convert(null, null, null, null));
        }

        [TestMethod()]
        [Tag("Redeem")]
        [Description("Unit Test Redeem")]
        public void OneRewardsPhoneAppRedeemTest()
        {
            OneRewardsPhoneApp.Views.Redeem Redeem = new OneRewardsPhoneApp.Views.Redeem();
            Assert.IsNotNull(Redeem);
            Assert.AreNotEqual(Redeem.Title, "");
            Assert.IsTrue(Redeem.IsEnabled);
        }

        [TestMethod()]
        [Tag("SummaryPage")]
        [Description("Unit Test SummaryPage")]
        public void OneRewardsPhoneAppSummaryPageTest()
        {
            OneRewardsPhoneApp.Views.SummaryPage SummaryPage = new OneRewardsPhoneApp.Views.SummaryPage();
            Assert.IsNotNull(SummaryPage);
            Assert.AreNotEqual(SummaryPage.Title, "");
            Assert.IsTrue(SummaryPage.IsEnabled);
        }

        //private method to set the login file
        private void WritePinToFile()
        {
            byte[] uData = Encoding.UTF8.GetBytes("atbneo@gmail.com");
            // Create a file in the application's isolated storage.
            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream writestream = new IsolatedStorageFileStream("ufile", System.IO.FileMode.Create, System.IO.FileAccess.Write, file);

            // Write pinData to the file.
            Stream writer = new StreamWriter(writestream).BaseStream;
            writer.Write(uData, 0, uData.Length);
            writer.Close();
            writestream.Close();
        }

    }
}
