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
        }
    }
}