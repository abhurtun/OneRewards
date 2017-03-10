using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using OneRewardsPhoneApp.Model;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Controls;
using OneRewardsPhoneApp.OneRewardsService;
using System.IO.IsolatedStorage;
using System.IO;
using System.Text;
using System.Threading;
using System.ComponentModel;


namespace OneRewardsPhoneApp.Views
{
    public partial class AddAccount : PhoneApplicationPage
    {
        private const string HAS_UNSAVED_CHANGES_KEY = "HasUnsavedChanges";
        private int cid;
        private int cardno = 0;
        private bool _hasUnsavedChanges;
        private TextBox _textboxWithFocus;
        private string Filepath = "ufile";


        /// <summary>
        /// Initializes a new instance of the AddAccount class.
        /// </summary>
        public AddAccount()
        {
            InitializeComponent();
            CardNoTextBox.KeyDown += delegate { _hasUnsavedChanges = true; };
            lpkCompanyNames.KeyDown += delegate { _hasUnsavedChanges = true; };
            GotFocus += AddAccountPage_GotFocus;
        }

        

        void AddAccountPage_GotFocus(object sender, RoutedEventArgs e)
        {
            _textboxWithFocus = e.OriginalSource as TextBox;
        }

        /// <summary>
        /// Called when navigating to this page; loads  
        /// and then initializes the page state.
        /// </summary>
        /// <param name="e">The event data.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Initialize the page state only if it is not already initialized,
            // and not when the application was deactivated but not tombstoned (returning from being dormant).
            if (DataContext == null)
            {
                InitializePageState();
                // Initialize the drop down list
                OneRewardsServiceClient Service = new OneRewardsServiceClient();
                Service.getCompanyNamesCompleted += new EventHandler<getCompanyNamesCompletedEventArgs>(Service_CompanyNames);
                Service.getCompanyNamesAsync();
            }



        }

        //This is the event delegate 
        void Service_CompanyNames(object sender, getCompanyNamesCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                MessageBox.Show("Cannot retrive companys");
            }
            else
            {
                this.lpkCompanyNames.ItemsSource = e.Result;
            }
        }

        /// <summary>
        /// Called when navigating away from this page; 
        /// and a value that indicates whether there are unsaved changes. 
        /// </summary>
        /// <param name="e">The event data.</param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            // Do not cache the page state when navigating backward 
            // or when there are no unsaved changes.
            if (e.Uri.OriginalString.Equals("//Views/MainMenuPage.xaml") ||
                !_hasUnsavedChanges) return;

            CommitTextBoxWithFocus();
            State[HAS_UNSAVED_CHANGES_KEY] = _hasUnsavedChanges;
        }

        /// <summary>
        /// Initializes the view and its data context. 
        /// </summary>
        private void InitializePageState()
        {
   
                // Delete temporary storage to avoid unnecessary storage costs.
                State.Clear();
        }

        /// <summary>
        /// Displays a warning dialog box if the user presses the back button
        /// and there are unsaved changes. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnBackKeyPress(
            System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);

            // If there are no changes, do nothing.
            if (!_hasUnsavedChanges) return;

            var result = MessageBox.Show("You are about to discard your " +
                "changes. Continue?", "Warning", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                
            }
            else
            {
                e.Cancel = true;
            }
        }


        /// <summary>
        /// Validates the entered card data and, if validation is successful, 
        /// saves the data and navigates back to the Mainmenu. 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private  void SaveButton_Click(object sender, EventArgs e)
        {
            CommitTextBoxWithFocus();
            if (!String.IsNullOrEmpty(CardNoTextBox.Text))
            {
            cardno =  Convert.ToInt32(CardNoTextBox.Text);
            }
            if (cardno <= 0)
            {
                MessageBox.Show("The card number is required and has to be a positve integer.");
                return;
            }

            if (string.IsNullOrWhiteSpace(lpkCompanyNames.SelectedItem.ToString()))
            {
                MessageBox.Show("The Company name is required.");
                return;
            }

            //inside the button click event create a background worker
            BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerAsync();

        }


        public void worker_RunWorkerCompleted(object sender,RunWorkerCompletedEventArgs e)
        {
            //once backgroudn work i.e. DoWork is complete this method will be 
            //called and code below will execute in UI thread
            addRewardsAccount();

            //NavigationService.GoBack();
        }

        public void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //it will wait 5 secs in the background thread
            getCompanyID();
            Thread.Sleep(5000);
        }

        private void getCompanyID()
        {



                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {                // Call Wcf service
                    OneRewardsServiceClient Service = new OneRewardsServiceClient();
                    Service.getCompanyIDCompleted += new EventHandler<getCompanyIDCompletedEventArgs>(Service_getCompanyID);
                    Service.getCompanyIDAsync(lpkCompanyNames.SelectedItem.ToString());
                });
       
        }

        private void addRewardsAccount()
        {

            // Call Wcf service
            OneRewardsServiceClient Service = new OneRewardsServiceClient();
            // Retrieve the username from isolated storage.
            byte[] uByte = this.ReadUFromFile();

            // Convert the PIN from byte to string and display it in the text box.
            String Username = Encoding.UTF8.GetString(uByte, 0, uByte.Length);

            //add new rewards account
            Service.addRewardsAccountCompleted += new EventHandler<addRewardsAccountCompletedEventArgs>(Service_RegisterAccount);
            //add new rewards account
            Service.addRewardsAccountAsync(cardno, cid, Username);           

        }


        //This is the event delegate 
        void Service_RegisterAccount(object sender, addRewardsAccountCompletedEventArgs e)
        {
            if (e.Result == false)
            {
                MessageBox.Show("Cannot register account");
            }
            else
            {
                MessageBox.Show("New Rewards Account Registered");
            }

        }

        //This is the event delegate 
        void Service_getCompanyID(object sender, getCompanyIDCompletedEventArgs e)
        {
            if (e.Result == 0)
            {
                MessageBox.Show("Cannot get company");
            }
            else
            {
                cid = e.Result;
            }

        }

        /// <summary>
        /// Displays a warning dialog box to confirm deletion of the reward accounts data. 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // Commit any uncommitted changes. Changes in a bound text box are 
            // normally committed to the data source only when the text box 
            // loses focus. However, application bar buttons do not receive or 
            // change focus because they are not Silverlight controls. 
            CommitTextBoxWithFocus();
            if (!String.IsNullOrEmpty(CardNoTextBox.Text))
            {
                cardno = Convert.ToInt32(CardNoTextBox.Text);
            }
            if (cardno <= 0)
            {
                MessageBox.Show("The card number is required and has to be a positve integer.");
                return;
            }

            var result = MessageBox.Show("You are about to delete the rewards account" +
                "and its entire history. Continue?", "Warning",
                MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                //inside the button click event create a background worker
                BackgroundWorker worker = new BackgroundWorker();
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted2);
                worker.DoWork += new DoWorkEventHandler(worker_DoWork);
                worker.RunWorkerAsync();


                // Reset the individual properties so that the bound
                // text boxes will update automatically.
                CardNoTextBox.Text = "0";
                _hasUnsavedChanges = false;
 
                
                var deleteButton = (ApplicationBarIconButton)this.ApplicationBar.Buttons[1];
                deleteButton.IsEnabled = false;
            }
        }

        //method to remove account
        private void removeRewardsAccount()
        {

            // Call Wcf service
            OneRewardsServiceClient Service = new OneRewardsServiceClient();
            Service.removeRewardsAccountCompleted += new EventHandler<removeRewardsAccountCompletedEventArgs>(Service_removeRewardsAccount);
            //remove rewards account
            Service.removeRewardsAccountAsync(cardno, cid);

        }

        //This is the event delegate 
        void Service_removeRewardsAccount(object sender, removeRewardsAccountCompletedEventArgs e)
        {
            if (e.Result == false)
            {
                MessageBox.Show("Cannot remove account");
            }
            else
            {
                MessageBox.Show("Rewards Account Removed");
            }

        }

        public void worker_RunWorkerCompleted2(object sender, RunWorkerCompletedEventArgs e)
        {
            //once backgroudn work i.e. DoWork is complete this method will be 
            //called and code below will execute in UI thread
            removeRewardsAccount();

            //NavigationService.GoBack();
        }

        /// <summary>
        /// Ensures that any changes to text box values are committed. 
        /// </summary>
        private void CommitTextBoxWithFocus()
        {
            if (_textboxWithFocus == null) return;

            System.Windows.Data.BindingExpression expression =
                _textboxWithFocus.GetBindingExpression(TextBox.TextProperty);
            if (expression != null) expression.UpdateSource();

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

    }
}