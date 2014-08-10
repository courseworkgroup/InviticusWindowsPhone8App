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
    public partial class WeightPage : PhoneApplicationPage
    {
        private BabyViewModel _babyViewModel;
        SharedInformation info = SharedInformation.getInstance();
        

        public WeightPage()
        {
            InitializeComponent();
            
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = info.bitmapImage;
            LayoutRoot.Background = imageBrush;
            
            //imageBrush.ImageSource = new BitmapImage(new Uri(@"Assets/Photo0277_edited.jpg", UriKind.Relative));
            int babyid = -1;
            babyid = info.babyID;
            _babyViewModel = new BabyViewModel(babyid);
            
            DataContext = _babyViewModel;

            llsWeight.ItemsSource = _babyViewModel.Weight;

        }

        private void add_weight(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddWeight.xaml?", UriKind.RelativeOrAbsolute));
        }

        void settings_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.RelativeOrAbsolute));
        }

        

    }
}