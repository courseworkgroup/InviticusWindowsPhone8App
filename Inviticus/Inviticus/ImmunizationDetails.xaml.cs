using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using Inviticus.ViewModels;

namespace Inviticus
{
    public partial class ImmunizationDetails : PhoneApplicationPage
    {
        private BabyViewModel _babyViewModel;
        SharedInformation info = SharedInformation.getInstance();
        public ImmunizationDetails()
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
            if (DataContext == null)
            {
                string selectedIndex = "";
                if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
                {
                    int index = int.Parse(selectedIndex);
                    _babyViewModel = new BabyViewModel(info.babyID);
                    _babyViewModel.VaccineChoosen(index);
                    VaccineTB.Text = _babyViewModel.Vaccine.Immunisation;
                    PeriodTB.Text = _babyViewModel.Vaccine.ImmunisationPeriod;
                    DetailsTB.Text = _babyViewModel.Vaccine.ImmunisationDetails;

                }
            }

            if (_babyViewModel.Vaccine.ImmunizationTaken)
            {
                administered.Visibility = Visibility.Collapsed;
                administeredTB.Visibility = Visibility.Collapsed;
                txt.Visibility = Visibility.Visible;
                dateCompleted.Visibility = Visibility.Visible;

                dateCompleted.Text = _babyViewModel.Vaccine.DateTaken;
            }
        }

        private void showDatePicker(object sender, RoutedEventArgs e)
        {
            if ((bool)administered.IsChecked)
            {
                txt.Visibility = Visibility.Visible;
                datePicker.Visibility = Visibility.Visible;
                ApplicationBar.IsVisible = true;
            }

            else
            {
                txt.Visibility = Visibility.Collapsed;
                datePicker.Visibility = Visibility.Collapsed;
                ApplicationBar.IsVisible = false;
            }
                
        }

        private void ApplicationBarSaveButton_Click(object sender, EventArgs e)
        {
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                int index = int.Parse(selectedIndex);
                DateTime dateTime = (DateTime)datePicker.Value;
                _babyViewModel.updateImmunisationData(dateTime.ToString("d"), true, index);
            }

            NavigationService.Navigate(new Uri("/Immunization.xaml", UriKind.RelativeOrAbsolute));


        }
    }
}