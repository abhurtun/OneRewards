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

namespace OneRewardsPhoneApp.Views
{
    public partial class MainMenuPage : PhoneApplicationPage
    {
        private readonly PhotoChooserTask _photoTask = new PhotoChooserTask();


        /// <summary>
        /// Initializes a new instance of the LoginPage class.
        /// </summary>
        public MainMenuPage()
        {
            InitializeComponent();
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
        /// Called when navigating away from this page; to add new rewards accounts
        /// </summary>
        /// <param name="e">The event data.</param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("//Views/AddAccount.xaml", UriKind.Relative));
        }

        /// <summary>
        /// Called when navigating away from this page; list of rewards accounts
        /// </summary>
        /// <param name="e">The event data.</param>
        private void ListButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("//Views/AccountList.xaml", UriKind.Relative));
        }





    }
}