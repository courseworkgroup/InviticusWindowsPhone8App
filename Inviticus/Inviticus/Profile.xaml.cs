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
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Inviticus
{
    public partial class Profile : PhoneApplicationPage
    {

        private BabyViewModel _babyViewModel;
        SharedInformation info = SharedInformation.getInstance();
        
        public Profile()
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
            try
            {
                babyPhoto.Source = info.getBabyPhoto(_babyViewModel.Baby.PhotoURI);
            }
            catch
            {
                babyPhoto.Source = new BitmapImage(new Uri(@"Assets/PanoramaBackground.png", UriKind.Relative));
            }

            birthWeight.Text = _babyViewModel.BirthWeight.BabyWeight; 
                     

        }

        void settings_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.RelativeOrAbsolute));
        }
                
    }
}