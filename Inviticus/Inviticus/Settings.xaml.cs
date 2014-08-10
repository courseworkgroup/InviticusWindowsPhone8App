using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;
using Inviticus.Model;
using Inviticus.Resources;
using System.Windows.Input;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media;

namespace Inviticus
{


    public partial class Settings : PhoneApplicationPage
    {
        SharedInformation info = SharedInformation.getInstance();
        PhotoChooserTask photoChooserTask;

        public Settings()
        {
            InitializeComponent();

            DataContext = App.ViewModel;
            photoChooserTask = new PhotoChooserTask();
            photoChooserTask.Completed += new EventHandler<PhotoResult>(photoChooserTask_Completed);
            App.ViewModel.LoadBabiesData();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = info.bitmapImage;
            LayoutRoot.Background = imageBrush;

            App.ViewModel.LoadData();
            //llsBabies.ItemsSource = App.ViewModel.Babies;
            
        }


        private void changeAppBackground_Click(object sender, RoutedEventArgs e)
        {
            photoChooserTask.Show();
        }

        public void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                MessageBox.Show(e.ChosenPhoto.Length.ToString());
                info.updateBackground(e.ChosenPhoto);
                
                
            }
        }

        private void llsBabies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (llsBabies.SelectedItem == null)
                return;

            info.babyID = (llsBabies.SelectedItem as Baby).Id;
            info.saveToIsolatedStorage();
            NavigationService.Navigate(new Uri("/MainPage.xaml?babyid=" + (llsBabies.SelectedItem as Baby).Id, UriKind.RelativeOrAbsolute));
            llsBabies.SelectedItem = null;
        }

        private void ApplicationBarAddButton_Click(object sender, EventArgs e)
        {
            
            NavigationService.Navigate(new Uri("/Registration.xaml", UriKind.RelativeOrAbsolute));
        }

        
        
    }

    public class List_ClassConverter : IValueConverter
    {
        SharedInformation info = SharedInformation.getInstance();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Baby MyList_Class = (Baby)value;

            //if (MyList_Class.PhotoURI != "ghostbusters-logo.jpg") return info.getBabyPhoto(MyList_Class.PhotoURI);

            try
            {
                return info.getBabyPhoto(MyList_Class.PhotoURI);
            }
            catch
            {
                return "Assets/PanoramaBackground.png";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    
}