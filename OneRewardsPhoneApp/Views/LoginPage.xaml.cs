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

namespace OneRewardsPhoneApp.Views
{
    public partial class LoginPage : PhoneApplicationPage
    {
        private const string HAS_UNSAVED_CHANGES_KEY = "HasUnsavedChanges";
        private readonly PhotoChooserTask _photoTask = new PhotoChooserTask();
        private bool _hasUnsavedChanges;
        private TextBox _textboxWithFocus;
        private string Filepath = "ufile";

        /// <summary>
        /// Initializes a new instance of the LoginPage class.
        /// </summary>
        public LoginPage()
        {
            InitializeComponent();
            EmailTextBox.KeyDown += delegate { _hasUnsavedChanges = true; };
            GotFocus += LoginPage_GotFocus;
        }

        

        void LoginPage_GotFocus(object sender, RoutedEventArgs e)
        {
            _textboxWithFocus = e.OriginalSource as TextBox;
        }

        /// <summary>
        /// Called when navigating to this page;  then initializes the page state.
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
            }

        }

        /// <summary>
        /// Called when navigating away from this page; stores the car data
        /// values and a value that indicates whether there are unsaved changes. 
        /// </summary>
        /// <param name="e">The event data.</param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            // Do not cache the page state when navigating backward 
            // or when there are no unsaved changes.
            if (e.Uri.OriginalString.Equals("//Views/SummaryPage.xaml") ||
                !_hasUnsavedChanges) return;
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
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);

        }

        /// <summary>
        /// Try to log in.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            OneRewardsServiceClient Service = new OneRewardsServiceClient();
            Service.autenticateCompleted += new EventHandler<autenticateCompletedEventArgs>(userService_AuthorizeUserCredentials);
            Service.autenticateAsync(EmailTextBox.Text);
        }

        //This is the event delegate 
        void userService_AuthorizeUserCredentials(object sender, autenticateCompletedEventArgs e)
        {
            if (e.Result == false)
            {
                MessageBox.Show("Invalid Credentails");
            }
            else
            {
                // Convert the PIN to a byte[].
                byte[] uByte = Encoding.UTF8.GetBytes(EmailTextBox.Text);

                // Store the encrypted PIN in isolated storage.
                this.WritePinToFile(uByte);

                NavigationService.Navigate(new Uri("//Views/MainMenuPage.xaml", UriKind.Relative));
            }
        }

        private void WritePinToFile(byte[] uData)
        {
            // Create a file in the application's isolated storage.
            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream writestream = new IsolatedStorageFileStream(Filepath, System.IO.FileMode.Create, System.IO.FileAccess.Write, file);

            // Write pinData to the file.
            Stream writer = new StreamWriter(writestream).BaseStream;
            writer.Write(uData, 0, uData.Length);
            writer.Close();
            writestream.Close();
        }

    }
}