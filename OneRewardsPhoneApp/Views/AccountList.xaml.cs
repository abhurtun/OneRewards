using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Controls;
using OneRewardsPhoneApp.OneRewardsService;
using System.IO.IsolatedStorage;
using System.IO;
using System.Text;
using System.Threading;
using System.ComponentModel;
using Microsoft.Phone;


namespace OneRewardsPhoneApp.Views
{
    public partial class AccountList : PhoneApplicationPage
    {
        private string Filepath = "ufile";
        // Constructor
        public AccountList()
        {
            InitializeComponent();
            getAccsList();//get all accounts

        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (ListData.SelectedItem != null)
            {
                ListData.SelectedIndex = -1;
            }

            base.OnNavigatedFrom(e);
        }

        private void getAccsList()
        {

            AccsListLabel.Text = "results are loading...";

            // Call Wcf service
            OneRewardsServiceClient Service = new OneRewardsServiceClient();
            Service.getAllRewardsAccountCompleted += new EventHandler<getAllRewardsAccountCompletedEventArgs>(Service_getAllRewardsAccount);

            // Retrieve the username from isolated storage.
            byte[] uByte = this.ReadUFromFile();

            // Convert the PIN from byte to string and display it in the text box.
            String Username = Encoding.UTF8.GetString(uByte, 0, uByte.Length);

            //get AllRewards Accounts
            Service.getAllRewardsAccountAsync(Username);

        }

        void Service_getAllRewardsAccount(object sender, getAllRewardsAccountCompletedEventArgs e)
        {
            //MessageBox.Show(e.ToString());

            try
            {
                //Bind the results to the list box that displays them in the UI
                ListData.DataContext = e.Result;

            }
            catch (System.Exception)
            {
                //That's okay, no results
            }

            if (ListData.Items.Count > 0)
            {
                AccsListLabel.Text = "results (tap acc number for details...)";
            }
            else
            {
                AccsListLabel.Text = "no results";
            }
        }
        
        /// <summary>
        /// Read username from file. 
        /// </summary>
        private byte[] ReadUFromFile()
        {
            // Access the file in the application's isolated storage.
            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream readstream = new IsolatedStorageFileStream(Filepath, System.IO.FileMode.Open, FileAccess.Read, file);

            // Read the PIN from the file.
            Stream reader = new StreamReader(readstream).BaseStream;
            byte[] pinArray = new byte[reader.Length];

            reader.Read(pinArray, 0, pinArray.Length);
            reader.Close();
            readstream.Close();

            return pinArray;
        }

        private void selection(object sender, SelectionChangedEventArgs e)
        {
            if (ListData.SelectedItem != null)
            {
                PhoneApplicationService.Current.State["RewardAccountID"] = ((OneRewardsService.RewardAccount)ListData.SelectedItem).RewardAccountID;
                PhoneApplicationService.Current.State["CompanyID"] = ((OneRewardsService.RewardAccount)ListData.SelectedItem).CompanyID;
                NavigationService.Navigate(new Uri("//Views/SummaryPage.xaml", UriKind.Relative));
            }
        }

    }//End page class


    public class PictureConverter : System.Windows.Data.IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //local variables
            int cid = (int)value;
            Object imgObj = null;

            //retrive from isolated storage
            var settings = IsolatedStorageSettings.ApplicationSettings;
            //update the image
            if (settings.TryGetValue<Object>(cid.ToString(), out imgObj))
            {
                MemoryStream memStream = new MemoryStream((byte[])imgObj);
                WriteableBitmap wbimg = PictureDecoder.DecodeJpeg(memStream);
                return wbimg;
            }
            else
            {
                return null;
            }

        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }    //End converter class
}//End namespace