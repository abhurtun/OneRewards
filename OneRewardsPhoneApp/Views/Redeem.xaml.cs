using System;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using OneRewardsPhoneApp.Model;
using OneRewardsPhoneApp.OneRewardsService;
using ZXing;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Microsoft.Phone.Shell;

namespace OneRewardsPhoneApp.Views
{
    public partial class Redeem : PhoneApplicationPage
    {
        private const string HAS_UNSAVED_CHANGES_KEY = "HasUnsavedChanges";
        private bool _hasUnsavedChanges;

        /// <summary>
        /// Initializes a new instance of the RedeemPage class.
        /// </summary>
        public Redeem()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Called when navigating to this page; 
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
            }

            // Set the barcode image
            long accid = (long)PhoneApplicationService.Current.State["RewardAccountID"];
            CreateBarcode(accid);

            // Delete temporary storage to avoid unnecessary storage costs.
            State.Clear();
        }

        /// <summary>
        /// Called when navigating away from this page; stores the  data
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
 
            _hasUnsavedChanges = State.ContainsKey(HAS_UNSAVED_CHANGES_KEY) && (bool)State[HAS_UNSAVED_CHANGES_KEY];

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
            e.Cancel = (result == MessageBoxResult.Cancel);
        }

        /// <summary>
        /// Validates the entered  data and, if validation is successful, 
        /// saves the data and navigates back to the SummaryPage. 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            //disable the application bar to avoid unwanted updates
            ApplicationBar.IsVisible = false;
            SaveResult result = new SaveResult();
            //set to true
            result.SaveSuccessful = true;

            if (result.SaveSuccessful)
            {
                //get variables
                long accid = (long)PhoneApplicationService.Current.State["RewardAccountID"];
                int cid = (int)PhoneApplicationService.Current.State["CompanyID"];
                //set flag
                Microsoft.Phone.Shell.PhoneApplicationService.Current
                    .State[Constants.FILLUP_SAVED_KEY] = true;

                // Call Wcf service
                OneRewardsServiceClient Service = new OneRewardsServiceClient();
                Service.updatePointsCompleted += new EventHandler<updatePointsCompletedEventArgs>(Service_updatePoints);
                Service.updatePointsAsync(accid,cid,randomNumber(50));
            }

        }

        void Service_updatePoints(object sender, updatePointsCompletedEventArgs e)
        {
            //MessageBox.Show(e.ToString());

            if(e.Result)
            {
                //Bind the results to the list box that displays them in the UI
                MessageBox.Show("Account has been updated.");
            }
            else
            {
                //That's okay, no results
                MessageBox.Show("Account cannot be updated!!!");
            }
            //re-enable the application bar to avoid unwanted updates
            ApplicationBar.IsVisible = true;
        }

        // Generate dummy redeem points data
        private long randomNumber(long number)
        {
            String num = number.ToString();
            int i = Convert.ToInt32(num.Substring(num.Length - 2));
            return (i + new Random().Next(50)) - 70;
        }

        //genearte barocode image
     private void CreateBarcode(long id)
    {
         //local variables
        int height = 100;
        int width = 100;

         // detect and decode the barcode inside the bitmap
        var bMatrix = new ZXing.Common.BitMatrix(width, height);
         //local varibale
        WriteableBitmap wbmi = new System.Windows.Media.Imaging.WriteableBitmap(width, height);
        wbmi = bMatrix.ToBitmap(BarcodeFormat.CODE_128, "*" + id.ToString() + "*");

        // do something with the result
        if (wbmi != null)
        {
            BarcodeImage.Source = wbmi;
        }
    }


    }
}
