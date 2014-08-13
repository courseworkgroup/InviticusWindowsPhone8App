using System;
using System.Linq;
using Microsoft.Phone.Controls;
using Inviticus.ViewModels;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Globalization;
using System.Collections;
using Inviticus.Model;

namespace Inviticus
{
    public partial class Chart : PhoneApplicationPage
    {
        

        public Chart()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //ImageBrush imageBrush = new ImageBrush();
            //imageBrush.ImageSource = info.bitmapImage;
            //LayoutRoot.Background = imageBrush;      

        }

    }

    // Class to store sales data

    public class ComputeWeightData : IEnumerable<WeightInfo>
    {
        private BabyViewModel _babyViewModel;
        SharedInformation info = SharedInformation.getInstance();
        public ObservableCollection<WeightInfo> WeightData { get; private set; }

        public IEnumerator<WeightInfo> GetEnumerator()
        {
            int babyid = -1;
            babyid = info.babyID;
            _babyViewModel = new BabyViewModel(babyid);
            String date;
            foreach (Weight weight in _babyViewModel.Weight)
            {
                date = weight.Date;
                yield return new WeightInfo { weightDate = DateTime.Parse(date, CultureInfo.InvariantCulture), weight = Convert.ToInt16(weight.BabyWeight) };
            } 

        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<WeightInfo>)this).GetEnumerator();
        }

    }

    public class WeightInfo
    {
        public DateTime weightDate { get; set; }
        public int weight { get; set; }
    }

}