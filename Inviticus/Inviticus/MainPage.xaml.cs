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

namespace Inviticus
{
    public partial class MainPage : PhoneApplicationPage
    {
        SharedInformation info = SharedInformation.getInstance();
        
        
        // Constructor
        public MainPage()
        {
            
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
                        
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = info.bitmapImage;
            LayoutRoot.Background = imageBrush;

            if (info.babyID == 0)
            {
                NavigationService.Navigate(new Uri("/Registration.xaml", UriKind.RelativeOrAbsolute));
            }

            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
            //change.Text = ToString('{0}', babyid);

            
            

            ////obj.SetSource(Application.GetResourceStream(new Uri(@"Assets/Photo0277_edited.jpg", UriKind.Relative)).Stream);


        }

        //public void BuildLocalizedApplicationBar()
        //{
        //    ApplicationBar = new ApplicationBar();
        //    ApplicationBar.Mode= ApplicationBarMode.Minimized;
        //   // ApplicationBarIconButton add = new ApplicationBarIconButton();
        //   // add.IconUri = new Uri("/Assets/Icons/add.png", UriKind.RelativeOrAbsolute);
        //   // ApplicationBar.Buttons.Add(add);

        //   // add.Click += add_Click;

        //    ApplicationBarMenuItem settings = new ApplicationBarMenuItem();
        //    settings.Text = AppResources.AppBarSettings;
        //    ApplicationBar.MenuItems.Add(settings);

        //    settings.Click += settings_Click;

        //}

       // void add_Click(object sender, EventArgs e)
       // {
       //     NavigationService.Navigate(new Uri("/Registration.xaml", UriKind.RelativeOrAbsolute));
       // }


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

        public void background(BitmapImage bitmapImage)
        {
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = bitmapImage;
            this.panorama.Background = imageBrush;
        }
    }
}