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
            DateTime bd = (DateTime)datePicker.Value;
            _babyViewModel.NewWeight.Date = bd.ToString("d");

            _babyViewModel.NewWeight.BabyWeight = weightMeasured.Text;

            _babyViewModel.AddNewWeight();
            NavigationService.Navigate(new Uri("/WeightPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }

}