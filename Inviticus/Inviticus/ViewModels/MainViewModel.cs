using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Inviticus.Model;
using Inviticus.Resources;

namespace Inviticus.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        private BabyDataContext context;

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        public ObservableCollection<ItemViewModel> Items2 { get; private set; }

        public ObservableCollection<ItemViewModel> Items3 { get; private set; }

        public ObservableCollection<ItemViewModel> Items4 { get; private set; }

        public ObservableCollection<ItemViewModel> Items5 { get; private set; }

        public ObservableCollection<Baby> Babies { get; private set; }

        public bool IsDataLoaded { get; private set; }

        public bool IsBabyDataLoaded { get; private set; }

        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
            this.Items2 = new ObservableCollection<ItemViewModel>();
            this.Items3 = new ObservableCollection<ItemViewModel>();
            this.Items4 = new ObservableCollection<ItemViewModel>();
            this.Items5 = new ObservableCollection<ItemViewModel>();
            this.Babies = new ObservableCollection<Baby>();

            context = new BabyDataContext(BabyDataContext.DBConnectionString);
            if (!context.DatabaseExists())
            {
                context.CreateDatabase();
                context.SubmitChanges();
            }
        }


        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }

        

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
            this.Items.Add(new ItemViewModel() { LineOne = "profile", LineTwo = "view the profile of the baby", });//LineThree = "Facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu" });
            this.Items.Add(new ItemViewModel() { LineOne = "immunization", LineTwo = "immunization information and days", }); //LineThree = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus" });
            this.Items.Add(new ItemViewModel() { LineOne = "development charts", LineTwo = "view and compare the development of your child", }); //LineThree = "Habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent" });

            this.Items2.Add(new ItemViewModel() { LineOne = "12/03/2014", LineTwo = "Measles immunisations" });
            this.Items2.Add(new ItemViewModel() { LineOne = "31/03/2014", LineTwo = "Weight measurement" });
            this.Items2.Add(new ItemViewModel() { LineOne = "12/04/2014", LineTwo = "Polio immunizations" });
            this.Items2.Add(new ItemViewModel() { LineOne = "15/04/2014", LineTwo = "BCG immunizations" });
            this.Items2.Add(new ItemViewModel() { LineOne = "31/04/2014", LineTwo = "Second Weight measurement" });

            this.Items3.Add(new ItemViewModel() { LineOne = "dailymail.co.uk", LineTwo = "new technology found for giving birth to babies, it is all a blur to the rest of us" });
            this.Items3.Add(new ItemViewModel() { LineOne = "telegraph.co.uk", LineTwo = "baby food that can be found for cheap in the uk stores" });
            this.Items3.Add(new ItemViewModel() { LineOne = "newpaper.co.uk", LineTwo = "the baby whisperer is back, find ways to talk to your new born with our experts" });
            this.Items3.Add(new ItemViewModel() { LineOne = "babymagazine.com", LineTwo = "things about your baby that you didnt know" });

            this.Items4.Add(new ItemViewModel() { Text = "baby one" });
            this.Items4.Add(new ItemViewModel() { Text = "baby two" });
            this.Items4.Add(new ItemViewModel() { Text = "baby three" });
            this.Items4.Add(new ItemViewModel() { Text = "baby four" });

            this.Items5.Add(new ItemViewModel() { ID = "0", LineOne = "BCG Immunization", LineTwo = "Given At Birth", LineThree = "the BCG vaccine is given against Tuberculosis, it is given at birth and is given on the right upper arm" });
            this.Items5.Add(new ItemViewModel() { ID = "1", LineOne = "Polio 0", LineTwo = "Given At Birth", LineThree = "The Polio Vaccine is given against Polio, the first of 4 doses and is administered through mouth drops" });
            this.Items5.Add(new ItemViewModel() { ID = "2", LineOne = "Polio 1", LineTwo = "Given At 6 Weeks", LineThree = "The Polio 1 Vaccine is given against Polio, it is the second of four doses and as is the nature with polio vaccines administered through mouth drops " });
            this.Items5.Add(new ItemViewModel() { ID = "3", LineOne = "DPT-HebB+Hib 1", LineTwo = "Given At 6 Weeks", LineThree = "The DPT-HebB+Hib 1 Vaccine is against a composition of diseases, Diphtheria, Tetanus, Whooping Cough, Hepatitis B, Haemophilus Influenza type B, it is the first of 3 doses and is administered on the left upper thigh" });
            this.Items5.Add(new ItemViewModel() { ID = "4", LineOne = "Polio 2", LineTwo = "Given At 10 Weeks", LineThree = "The Polio 2 Vaccine is given against Polio, it is the third of four doses and is administered through mouth drops" });
            this.Items5.Add(new ItemViewModel() { ID = "5", LineOne = "DPT-HebB+Hib 2", LineTwo = "Given At 10 Weeks", LineThree = "The DPT-HebB+Hib 2 Vaccine is against a composition of diseases, Diphtheria, Tetanus, Whooping Cough, Hepatitis B, Haemophilus Influenza type B, it is the second of 3 doses and is administered on the left upper thigh" });
            this.Items5.Add(new ItemViewModel() { ID = "6", LineOne = "Polio 3", LineTwo = "Given At 14 Weeks", LineThree = "The Polio 2 Vaccine is given against Polio, it is the third of four doses and is administered through mouth drops" });
            this.Items5.Add(new ItemViewModel() { ID = "7", LineOne = "DPT-HebB+Hib 3", LineTwo = "Given At 14 Weeks", LineThree = "The DPT-HebB+Hib 3 Vaccine is against a composition of diseases, Diphtheria, Tetanus, Whooping Cough, Hepatitis B, Haemophilus Influenza type B, it is the last of the 3 doses and is administered on the left upper thigh" });
            this.Items5.Add(new ItemViewModel() { ID = "8", LineOne = "Measles", LineTwo = "Given At 9 months", LineThree = "The Measles vaccine is given against the Measles disease, it is the last vaccine received and is administered on the left upper arm" });

            this.IsDataLoaded = true;
        }

        public void LoadBabiesData()
        {
            if (context.Babies.Count() > 0)
            {
                List<Baby> babyList = context.Babies.ToList();
                Babies = new ObservableCollection<Baby>(babyList);
            }

            IsBabyDataLoaded = true;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}