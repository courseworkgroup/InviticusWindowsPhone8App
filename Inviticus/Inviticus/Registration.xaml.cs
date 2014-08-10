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
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;
using System.IO;
using System.Windows.Media;

namespace Inviticus
{
    public partial class Registration : PhoneApplicationPage
    {
        SharedInformation info = SharedInformation.getInstance();
        PhotoChooserTask photoChooserTask;
        public string fileName { get; private set; }

        public Registration()
        {
            InitializeComponent();
            photoChooserTask = new PhotoChooserTask();
            photoChooserTask.Completed += new EventHandler<PhotoResult>(photoChooserTask_Completed);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = info.bitmapImage;
            LayoutRoot.Background = imageBrush;

            int babyid = -1;
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("babyid", out selectedIndex))
            {
                babyid = int.Parse(selectedIndex);
                _babyViewModel = new BabyViewModel(babyid);
            }
            else
            {
                _babyViewModel = new BabyViewModel();
            }

            DataContext = _babyViewModel;

            _babyViewModel.InitializeNewWeight();
        }

        private void choosephoto_Click(object sender, RoutedEventArgs e)
        {
            photoChooserTask.Show();
        }

        public void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                string filePath =  e.OriginalFileName;
                fileName = Path.GetFileName(filePath);

                MessageBox.Show(e.ChosenPhoto.Length.ToString());
                info.saveBabyPhoto(e.ChosenPhoto, fileName);

                this.babyphoto.Source = info.getBabyPhoto(fileName);
                                
            }
            
        }
        private BabyViewModel _babyViewModel;
       

        

        private void ApplicationBarSaveButton_Click(object sender, EventArgs e)
        {
            if (fileName != null)
                babyPhoto.Text = fileName;

            _babyViewModel.AddNewWeight();
            _babyViewModel.Save();
            NavigationService.Navigate(new Uri("/Settings.xaml?", UriKind.RelativeOrAbsolute));

        }

        private void ApplicationBarCancelCourseButton_Click_1(object sender, EventArgs e)
        {

        }

        private void maleChecked(object sender, RoutedEventArgs e)
        {            
            gender.Text = "Male";
        }

        private void femaleChecked(object sender, RoutedEventArgs e)
        {
            gender.Text = "Female";
        }

        private void weight_Date(object sender, EventArgs e)
        {
            weightDate.Text = birthDate.Text;
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