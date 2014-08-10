using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviticus.Model
{
    [Table(Name = "Weight")]
    public class Weight : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private int _weightid;
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int WeightId
        {
            get
            {
                return _weightid;
            }

            set
            {
                if (_weightid != value)
                {
                    NotifyPropertyChanging("WeightId");
                    _weightid = value;
                    NotifyPropertyChanged("WeightId");
                }
            }
        }

        private string _date;
        [Column(DbType = "nvarchar(255)", CanBeNull = false)]
        public string Date
        {
            get
            {
                return _date;
            }

            set
            {
                if (_date != value)
                {
                    NotifyPropertyChanging("Date");
                    _date = value;
                    NotifyPropertyChanged("Date");
                }
            }
        }

        private string _babyWeight;
        [Column(DbType = "nvarchar(255)", CanBeNull = false)]
        public string BabyWeight
        {
            get
            {
                return _babyWeight;
            }

            set
            {
                if (_babyWeight != value)
                {
                    NotifyPropertyChanging("BabyWeight");
                    _babyWeight = value;
                    NotifyPropertyChanged("BabyWeight");
                }
            }
        }

        private string _weightComment;
        public string WeightComment
        {
            get
            {
                return _weightComment;
            }
            set
            {
                if(_weightComment != value)
                {
                    NotifyPropertyChanging("WeightComment");
                    _weightComment = value;
                    NotifyPropertyChanged("WeightComment");
                }
            }
        }

        private EntityRef<Baby> _baby;
        [Association(Name = "FK_Baby_Weight", Storage = "_baby", ThisKey = "BabyId",
        OtherKey = "Id", IsForeignKey = true)]
        public Baby Baby
        {
            get
            {
                return _baby.Entity;
            }
            set
            {
                NotifyPropertyChanging("Baby");
                _baby.Entity = value;

                if (value != null)
                {
                    _babyid = value.Id;
                }

                NotifyPropertyChanged("Baby");
            }
        }

        public int _babyid;
        [Column(CanBeNull = false)]
        public int BabyId
        {
            get
            {
                return _babyid;
            }
            set
            {
                if (_babyid != value)
                {
                    NotifyPropertyChanging("BabyId");
                    _babyid = value;
                    NotifyPropertyChanged("BabyId");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify the data context that a data context property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify the page that a data context property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
