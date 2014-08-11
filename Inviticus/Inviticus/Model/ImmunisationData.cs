using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace Inviticus.Model
{
        [Table(Name = "ImmunisationData")]
        public class ImmunisationData : INotifyPropertyChanged, INotifyPropertyChanging
        {
            private int _immunisationDataid;
            [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
            public int ImmunisationDataId
            {
                get
                {
                    return _immunisationDataid;
                }

                set
                {
                    if (_immunisationDataid != value)
                    {
                        NotifyPropertyChanging("ImmunisationDataId");
                        _immunisationDataid = value;
                        NotifyPropertyChanged("ImmunisationDataId");
                    }
                }
            }

            private string _immunisation;
            [Column(DbType = "nvarchar(255)", CanBeNull = false)]
            public string Immunisation
            {
                get
                {
                    return _immunisation;
                }

                set
                {
                    if (_immunisation != value)
                    {
                        NotifyPropertyChanging("Immunisation");
                        _immunisation = value;
                        NotifyPropertyChanged("Immunisation");
                    }
                }
            }

            private string _immunisationDetails;
            [Column(DbType = "nvarchar(255)", CanBeNull = false)]
            public string ImmunisationDetails
            {
                get
                {
                    return _immunisationDetails;
                }

                set
                {
                    if (_immunisationDetails != value)
                    {
                        NotifyPropertyChanging("ImmunisationDetails");
                        _immunisationDetails = value;
                        NotifyPropertyChanged("ImmunisationDetails");
                    }
                }
            }

            private string _immunisationPeriod;
            [Column(DbType = "nvarchar(255)", CanBeNull = false)]
            public string ImmunisationPeriod
            {
                get
                {
                    return _immunisationPeriod;
                }

                set
                {
                    if (_immunisationPeriod != value)
                    {
                        NotifyPropertyChanging("ImmunisationPeriod");
                        _immunisationPeriod = value;
                        NotifyPropertyChanged("ImmunisationPeriod");
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

            private bool _immunizationTaken;
            [Column(DbType = "nvarchar(255)", CanBeNull = false)]
            public bool ImmunizationTaken
            {
                get
                {
                    return _immunizationTaken;
                }

                set
                {
                    if (_immunizationTaken != value)
                    {
                        NotifyPropertyChanging("ImmunizationTaken");
                        _immunizationTaken = value;
                        NotifyPropertyChanged("ImmunizationTaken");
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

            private int _babyid;
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
