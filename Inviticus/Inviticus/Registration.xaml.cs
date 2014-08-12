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
        ComputeImmunization comp = ComputeImmunization.getInstance();
        Notifications notify = Notifications.getInstance();

        PhotoChooserTask photoChooserTask;
		private BabyViewModel _babyViewModel;

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
               

        private void ApplicationBarSaveButton_Click(object sender, EventArgs e)
        {
            if (fileName != null)
                babyPhoto.Text = fileName;

            DateTime bd = (DateTime)datePicker.Value;
            _babyViewModel.Baby.BirthDate = bd.ToString("d");
            _babyViewModel.NewWeight.Date = bd.ToString("d");

            _babyViewModel.Baby.MotherName = motherName.Text;
            _babyViewModel.AddNewWeight();
            _babyViewModel.Save();

            NavigationService.Navigate(new Uri("/MainPage.xaml?babyid=", UriKind.RelativeOrAbsolute));

            info.babyID = _babyViewModel.Baby.Id;
            info.saveToIsolatedStorage();

             //Compute immunisation dates
             DateTime date = new DateTime();
             date = Convert.ToDateTime(_babyViewModel.Baby.BirthDate);
             comp.computeImmunizationData(date);  
            
            //Notifications
             notify.SetNotification();
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
    }
}