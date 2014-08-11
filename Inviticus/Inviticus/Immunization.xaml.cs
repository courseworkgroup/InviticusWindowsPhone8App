using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Inviticus.Resources;
using Inviticus.ViewModels;
using Inviticus.Model;
using System.Windows.Media;

namespace Inviticus
{
    public partial class Immunization : PhoneApplicationPage
    {
        private BabyViewModel _babyViewModel;
        SharedInformation info = SharedInformation.getInstance();
        //Constructor to initialise the values

        public Immunization()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = info.bitmapImage;
            LayoutRoot.Background = imageBrush;

            int babyid = -1;
            babyid = info.babyID;
            _babyViewModel = new BabyViewModel(babyid);

            DataContext = _babyViewModel;

            llsImmunizationList.ItemsSource = _babyViewModel.ImmunisationData;
        }

        private void llsImmunizationList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //check if one of the list items has been selected, if not do nothing
            if (llsImmunizationList.SelectedItem == null)
                return;

            //navigate to the new page required, with an input of the selected input
            //NavigationService.Navigate(new Uri("/ImmunizationDetails.xaml?selectedItem="+ (ImmunizationList.SelectedItem as ItemViewModel).ID, UriKind.RelativeOrAbsolute));
            NavigationService.Navigate(new Uri("/ImmunizationDetails.xaml?selectedItem=" + (llsImmunizationList.SelectedItem as ImmunisationData).ImmunisationDataId, UriKind.RelativeOrAbsolute));

            //reset the selection 
           llsImmunizationList.SelectedItem = null;
        }
    }
}