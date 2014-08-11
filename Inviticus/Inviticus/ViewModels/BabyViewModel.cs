using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Inviticus.Model;

namespace Inviticus.ViewModels
{
    public class BabyViewModel : INotifyPropertyChanged
    {
        SharedInformation info = SharedInformation.getInstance();
        private BabyDataContext context = new BabyDataContext(BabyDataContext.DBConnectionString);

        public ObservableCollection<Weight> Weight { get; private set; }

        public ObservableCollection<ImmunisationData> ImmunisationData { get; private set; }

        public Weight BirthWeight { get;  private set; }

        public ImmunisationData Vaccine { get; private set; }

        private Weight _newWeight;

        public Weight NewWeight
        {
            get
            {
                return _newWeight;
            }
            set
            {
                _newWeight = value;
                NotifyPropertyChanged("NewWeight");
            }
        }

        private ImmunisationData _newImmunisationData;

        public ImmunisationData NewImmunisationData
        {
            get
            {
                return _newImmunisationData;
            }
            set
            {
                _newImmunisationData = value;
                NotifyPropertyChanged("NewImmunisationData");
            }
        }

        private Baby _baby;

        public Baby Baby
        {
            get
            {
                return _baby;
            }
            set
            {
                _baby = value;
                NotifyPropertyChanged("Baby");
            }
        }

        public BabyViewModel() 
        {
            this.Baby = new Baby();
        }

        public BabyViewModel(int babyid)
        {
            this.Baby = context.Babies.Where(b => b.Id == babyid).FirstOrDefault();

            context.SubmitChanges();

            LoadWeights();
            LoadImmunisationData();
        }

        private void LoadWeights()
        {
            List<Weight> weightList = context.Weights.Where(n => n.BabyId == this.Baby.Id).ToList();
            this.Weight = new ObservableCollection<Weight>(weightList);

            BirthWeight = context.Weights.Where(n => n.Date == n.Baby.BirthDate).FirstOrDefault();

        }

        private void LoadImmunisationData()
        {
            List<ImmunisationData> immunisationDataList = context.ImmunisationDatas.Where(n => n.BabyId == this.Baby.Id).ToList();
            this.ImmunisationData = new ObservableCollection<ImmunisationData>(immunisationDataList);

        }
        
		
        public void Save()
        {
            if (Baby.Id <= 0)
            {
                context.Babies.InsertOnSubmit(Baby);
            }

            context.SubmitChanges();
        }

        public void InitializeNewWeight()
        {
            NewWeight = new Weight();
            NewWeight.Baby = this.Baby;
            NewWeight.BabyWeight = "";
            NewWeight.Date = "";
            NewWeight.WeightComment = "";
        }

        public void InitializeNewImmunisationData()
        {
            NewImmunisationData = new ImmunisationData();
            NewImmunisationData.Baby = this.Baby;
            NewImmunisationData.Immunisation = "";
            NewImmunisationData.ImmunizationTaken = false;
            NewImmunisationData.Date = "";
            NewImmunisationData.ImmunisationDetails = "";
            NewImmunisationData.ImmunisationPeriod = "";
        }

        public void AddNewWeight()
        {
            context.Weights.InsertOnSubmit(NewWeight);
            context.SubmitChanges();
            LoadWeights();
        }

        public void AddNewImmunisationData()
        {
            context.ImmunisationDatas.InsertOnSubmit(NewImmunisationData);
            context.SubmitChanges();
            LoadImmunisationData();
        }

        public void VaccineChoosen(int value)
        {
           this.Vaccine = context.ImmunisationDatas.Where(n => n.ImmunisationDataId == value).FirstOrDefault();
        }

        public void updateImmunisationTaken()
        {
            this.Baby.IsImmunisationDataComplete = true;
            context.SubmitChanges();

        }

        public void updatePhotoURI(string newPhoto)
        {
            this.Baby.PhotoURI = newPhoto;
            context.SubmitChanges();
        }

        public void updateImmunisationData(string date, bool value, int location)
        {
            NewImmunisationData = new ImmunisationData();
            NewImmunisationData = context.ImmunisationDatas.Where(b => b.ImmunisationDataId == location).FirstOrDefault();
            NewImmunisationData.DateTaken = date;
            NewImmunisationData.ImmunizationTaken = value;

            context.SubmitChanges();
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
