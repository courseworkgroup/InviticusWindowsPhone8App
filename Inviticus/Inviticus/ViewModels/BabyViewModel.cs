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

        public Weight BirthWeight { get;  private set; }

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
        }

        private void LoadWeights()
        {
            List<Weight> weightList = context.Weights
                .Where(n => n.BabyId == this.Baby.Id)
                .ToList();
            this.Weight = new ObservableCollection<Weight>(weightList);
            foreach (Weight weight in weightList)
            {
                if (weight.BabyId == this.Baby.Id && weight.Date.Equals(this.Baby.BirthDate))
                {
                    BirthWeight = weight;
                }
                break;
            }
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

        public void AddNewWeight()
        {
            context.Weights.InsertOnSubmit(NewWeight);
            context.SubmitChanges();
            LoadWeights();
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
