using System;
using System.Reflection;
using System.Windows;
using System.Windows.Navigation;
using OneRewardsPhoneApp.Model;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Controls;
using OneRewardsPhoneApp.OneRewardsService;
using System.IO.IsolatedStorage;

namespace OneRewardsPhoneApp.Views
{
    public partial class SummaryPage : PhoneApplicationPage
    {
                /// <summary>
        /// Initializes a new instance of the SummaryPage class.
        /// </summary>
        public SummaryPage()
        {
            InitializeComponent();
            //get the logos then reenbale card button
            addCompanyInfo();
        }

        /// <summary>
        /// Called when navigating to this page; loads the card data from storage 
        /// on the first navigation (that is, at application launch and
        /// reactivation) and initializes the page state.
        /// </summary>
        /// <param name="e">The event data.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Initialize the page state only if it is not already initialized,
            // and not when the application was deactivated but not tombstoned (returning from being dormant).
            InitializePageState();

            // Determine whether the RewardAccountID object is empty by checking for an 
            // initial RewardAccountID. 
            bool isRewardAccIDValid = !PhoneApplicationService.Current.State.ContainsKey("RewardAccountID");

            // Display the instruction panel only if the RewardAccountID object is empty.
            InstructionPanel.Visibility =
                isRewardAccIDValid ? Visibility.Visible : Visibility.Collapsed;

            // Display the pivot control only if the RewardAccountID object is not empty.
            SummaryPivot.Visibility =
                isRewardAccIDValid ? Visibility.Collapsed : Visibility.Visible;

            // Enable the fill-up button only if the RewardAccountID object is not empty. 
            (ApplicationBar.Buttons[0] as ApplicationBarIconButton).IsEnabled =
                !isRewardAccIDValid;

            // Diable the card button only if the RewardAccountID object is not empty. 
            (ApplicationBar.Buttons[1] as ApplicationBarIconButton).IsEnabled = false;


                
        }

        /// <summary>
        /// Called when navigating away from this page; stores the index of the 
        /// current pivot item.
        /// </summary>
        /// <param name="e">The event data.</param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            // Initialize the page state only if it is not already initialized,
            // and not when the application was deactivated but not tombstoned (returning from being dormant).
            InitializePageState();
        }

        /// <summary>
        /// Initializes the view. 
        /// </summary>
        private void InitializePageState()
        {
            if (PhoneApplicationService.Current.State.ContainsKey("RewardAccountID"))
            {
                // Call Wcf service
                OneRewardsServiceClient Service = new OneRewardsServiceClient();
                Service.getRewardsAccountCompleted += new EventHandler<getRewardsAccountCompletedEventArgs>(Service_getRewardsAccountCompleted);
                //get Reward Accounts
                long accid = (long) PhoneApplicationService.Current.State["RewardAccountID"];
                int cid = (int) PhoneApplicationService.Current.State["CompanyID"];

                Service.getRewardsAccountAsync(accid,cid);
            }

        }

        void Service_getRewardsAccountCompleted(object sender, getRewardsAccountCompletedEventArgs e)
        {
            //MessageBox.Show(e.ToString());

            try
            {
                //Bind the results to the list box that displays them in the UI
               OneRewardsService.RewardAccount acc = e.Result;
               ctotal.Text = acc.TotalPoints.ToString();
               lpoints.Text =  acc.Points.ToString();
               accid.Text = acc.RewardAccountID.ToString();

            }
            catch (System.Exception)
            {
                //That's okay, no results
            }

        }

        /// <summary>
        /// Navigates to the redeem page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void FillupButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(
                new Uri("//Views/Redeem.xaml", UriKind.Relative));
        }

        /// <summary>
        /// Navigates to the car details page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void CardButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("//Views/LoginPage.xaml", UriKind.Relative));
            
        }

        /// <summary>
        /// Displays the ONE REWARDS version number and support URL.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            string fullName = Assembly.GetExecutingAssembly().FullName;
            AssemblyName assemblyName = new AssemblyName(fullName);
            string productTitle = null;

            object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);

            if ((customAttributes.Length > 0))
            {
                productTitle = ((AssemblyTitleAttribute)customAttributes[0]).Title;
            }

            MessageBox.Show(productTitle + " sample application" +
                Environment.NewLine + "version " + assemblyName.Version +
                Environment.NewLine + "http://onerewards.azurewebsites.net",
                "About ONE REWARDS", MessageBoxButton.OK);
        }


        /// <summary>
        /// Get all the company info before loading the app.
        /// </summary>
        private void addCompanyInfo()
        {

            // Call Wcf service
            OneRewardsServiceClient Service = new OneRewardsServiceClient();
            Service.getCompanysCompleted += new EventHandler<getCompanysCompletedEventArgs>(Service_getCompanys);
            Service.getCompanysAsync();
        }

        void Service_getCompanys(object sender, getCompanysCompletedEventArgs e)
        {
            (ApplicationBar.Buttons[1] as ApplicationBarIconButton).IsEnabled = false;
            try
            {

                //save company
                var settings = IsolatedStorageSettings.ApplicationSettings;
                //retrieve the logos
                foreach (Company i in e.Result)
                {
                    if (settings.Contains(i.CompanyID.ToString()))
                    {
                        settings[i.CompanyID.ToString()] = i.CompanyLogo;
                    }
                    else
                    {
                        settings.Add(i.CompanyID.ToString(), i.CompanyLogo);
                    }

                    
                    settings.Save();
                    // at that point the web service returned
                }
                if (!PhoneApplicationService.Current.State.ContainsKey("RewardAccountID"))
                {
                    (ApplicationBar.Buttons[1] as ApplicationBarIconButton).IsEnabled = true;
                }
            }
            catch (Exception)
            {
                //That's okay, no results
            }


        }
    }
}
