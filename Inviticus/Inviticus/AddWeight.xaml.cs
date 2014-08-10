using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Inviticus.ViewModels;
using System.Windows.Media;

namespace Inviticus
{
    public partial class AddWeight : PhoneApplicationPage
    {

        private BabyViewModel _babyViewModel;
        SharedInformation info = SharedInformation.getInstance();

        public AddWeight()
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

            _babyViewModel.InitializeNewWeight();
        }

        private void save_weight(object sender, EventArgs e)
        {
            _babyViewModel.AddNewWeight();
            NavigationService.Navigate(new Uri("/WeightPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void obeseChecked(object sender, RoutedEventArgs e)
        {
            weightComment.Text = "Obese";
        }

        private void goodChecked(object sender, RoutedEventArgs e)
        {
            weightComment.Text = "Good";
        }

        private void averageChecked(object sender, RoutedEventArgs e)
        {
            weightComment.Text = "Average";
        }

        private void badChecked(object sender, RoutedEventArgs e)
        {
            weightComment.Text = "Bad";
        }
    }

}