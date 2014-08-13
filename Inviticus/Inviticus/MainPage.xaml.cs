using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Inviticus.Resources;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Documents;
using System.Windows.Media.Animation;
using System.Windows.Input;
using System.Windows.Shapes;
using Inviticus.ViewModels;
using Inviticus.Model;

namespace Inviticus
{
    public partial class MainPage : PhoneApplicationPage
    {
        SharedInformation info = SharedInformation.getInstance();
        private BabyViewModel _babyViewModel;
        
        // Constructor
        public MainPage()
        {
            
            InitializeComponent();
            Loaded += MainPage_Loaded;

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
                        
        }
		
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.RemoveBackEntry();
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = info.bitmapImage;
            LayoutRoot.Background = imageBrush;


            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }

            int babyid = -1;
            babyid = info.babyID;
            _babyViewModel = new BabyViewModel(babyid);

            llsEvents.ItemsSource = _babyViewModel.ImmunisationIncomplete;

        }

        void settings_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Immunization_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Immunization.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Weight_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/WeightPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Profile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Profile.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Chart_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Chart.xaml", UriKind.RelativeOrAbsolute));
        }

        private void llsEvent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //check if one of the list items has been selected, if not do nothing
            if (llsEvents.SelectedItem == null)
                return;

            //navigate to the new page required, with an input of the selected input
            //NavigationService.Navigate(new Uri("/ImmunizationDetails.xaml?selectedItem="+ (ImmunizationList.SelectedItem as ItemViewModel).ID, UriKind.RelativeOrAbsolute));
            NavigationService.Navigate(new Uri("/ImmunizationDetails.xaml?selectedItem=" + (llsEvents.SelectedItem as ImmunisationData).ImmunisationDataId, UriKind.RelativeOrAbsolute));

            //reset the selection 
            llsEvents.SelectedItem = null;
        }

    }
}