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
using Syncfusion.UI.Xaml.Charts;
using System.Windows.Media.Imaging;

namespace Inviticus
{
    public partial class Chart : PhoneApplicationPage
    {
        SharedInformation info = SharedInformation.getInstance();
        ObservableCollection<Weight> weightList = new ObservableCollection<Weight>();
        WeightForAgeBirthTo5Years_Boys weightBoys = new WeightForAgeBirthTo5Years_Boys();
        WeightForAgeBirthTo5Years_Girls weightGirls = new WeightForAgeBirthTo5Years_Girls();
        SfChart chart = new SfChart();
        BabyViewModel _babyViewModel;
        public Chart()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = info.bitmapImage;
            LayoutRoot.Background = imageBrush;

            imageBrush.ImageSource = new BitmapImage(new Uri(@"Assets/Photo0277_edited.jpg", UriKind.Relative));

            int babyid = -1;
            babyid = info.babyID;
            _babyViewModel = new BabyViewModel(babyid);

            String gender = _babyViewModel.Baby.Gender;
            if (gender.Equals("Male"))
            {
                int index = _babyViewModel.Weight.Count();
                info.getWHOChildGrowthStandards(weightBoys.json);
                info.computeWHOGrowthStandards(_babyViewModel.Baby, index);
            }
            else if (gender.Equals("Female"))
            {
                int index = _babyViewModel.Weight.Count();
                info.getWHOChildGrowthStandards(weightGirls.json);
                info.computeWHOGrowthStandards(_babyViewModel.Baby, index);
            }
            DataContext = _babyViewModel;

            
            this.weightList =_babyViewModel.Weight;

            createChart();
            this.ContentPanel.Children.Add(this.chart);
        }

        protected void createChart()
        {          

            this.chart.Header = "Babies Weights";

            //Adding horizontal axis to the chart

            CategoryAxis primaryCategoryAxis = new CategoryAxis();

            primaryCategoryAxis.Header = "Date";

            this.chart.PrimaryAxis = primaryCategoryAxis;


            //Adding vertical axis to the chart 

            NumericalAxis secondaryNumericalAxis = new NumericalAxis();

            secondaryNumericalAxis.Header = "Weight";

            this.chart.SecondaryAxis = secondaryNumericalAxis;


            //Initialize the two series for SfChart
            LineSeries series1 = new LineSeries();
            LineSeries series2 = new LineSeries();
            LineSeries series3 = new LineSeries();
            LineSeries series4 = new LineSeries();

            series1.ItemsSource = _babyViewModel.Weight;

            series1.XBindingPath = "Date";

            series1.YBindingPath = "BabyWeight";

            series1.Label = "Babies";

            series2.ItemsSource = info.p10;

            series2.XBindingPath = "Date";

            series2.YBindingPath = "BabyWeight";

            series2.Label = "P10";

            series3.ItemsSource = info.p50;

            series3.XBindingPath = "Date";

            series3.YBindingPath = "BabyWeight";

            series3.Label = "P50";

            series4.ItemsSource = info.p75;

            series4.XBindingPath = "Date";

            series4.YBindingPath = "BabyWeight";

            series4.Label = "P75";

            //Adding Series to the Chart Series Collection
            chart.Series.Add(series1);
            chart.Series.Add(series2);
            chart.Series.Add(series3);
            chart.Series.Add(series4);

            //Adding Legends for the chart
            ChartLegend legend = new ChartLegend();

            legend.Visibility = System.Windows.Visibility.Visible;

            this.chart.Legend = legend;

        }

    }
}