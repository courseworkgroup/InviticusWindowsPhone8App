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
    [Table(Name = "Baby")]
    public class Baby : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public Baby()
        {
            _weight = new EntitySet<Weight>(
                weight =>
                {
                    NotifyPropertyChanging("Weight");
                    weight.Baby = this;
                },
                weight =>
                {
                    NotifyPropertyChanging("Weight");
                    weight.Baby = null;
                }
             );
        }

        private int _id;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    NotifyPropertyChanging("Id");
                    _id = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }

        private string _name;

        [Column(DbType = "nvarchar(255)", CanBeNull = false)]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    NotifyPropertyChanging("Name");
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        private string _birthDate;

        [Column(DbType = "nvarchar(255)", CanBeNull = false)]
        public string BirthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                if (_birthDate != value)
                {
                    NotifyPropertyChanging("BirthDate");
                    _birthDate = value;
                    NotifyPropertyChanged("BirthDate");
                }
            }
        }

        private string _gender;

        [Column(DbType = "nvarchar(255)", CanBeNull = false)]
        public string Gender
        {
            
            get
            {
                return _gender;
            }
            set
            {
                if (_gender != value)
                {
                    NotifyPropertyChanging("Gender");
                    _gender = value;
                    NotifyPropertyChanged("Gender");
                }
            }
        }

        private string _fatherName;

        [Column(DbType = "nvarchar(255)", CanBeNull = false)]
        public string FatherName
        {
            get
            {
                return _fatherName;
            }
            set
            {
                if (_fatherName != value)
                {
                    NotifyPropertyChanging("FatherName");
                    _fatherName = value;
                    NotifyPropertyChanged("FatherName");
                }
            }
        }

        private string _motherName;
        [Column(DbType = "nvarchar(255)", CanBeNull = false)]

        public string MotherName 
        { 
            get 
            {
                return _motherName;
            } 
            set 
            {
                if (_motherName != value)
                {
                    NotifyPropertyChanging("MotherName");
                    _motherName = value;
                    NotifyPropertyChanged("MotherName");
                }
            } 
        }

        private string _photoURI;

        [Column(DbType = "nvarchar(255)", CanBeNull = false)]
        public string PhotoURI
        {
            get
            {
                return _photoURI;
            }
            set
            {
                if (_photoURI != value)
                {
                    NotifyPropertyChanging("PhotoURI");
                    _photoURI = value;
                    NotifyPropertyChanged("PhotoURI");
                }
            }
        }

        private EntitySet<Weight> _weight;

        [Association(Name = "FK_Baby_Weight", Storage = "_weight", ThisKey = "Id", OtherKey = "WeightId")]
        public EntitySet<Weight> Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight.Assign(value);
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
