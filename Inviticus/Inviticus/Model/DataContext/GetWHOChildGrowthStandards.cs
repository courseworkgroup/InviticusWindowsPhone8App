using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviticus.Model.DataContext
{
    public class GetWHOChildGrowthStandards
    {
        public ObservableCollection<WHOChildGrowthStandards> childGrowth { get; set; }
        public ObservableCollection<WHOChildGrowthStandards> DataElements(String json)
        {
            try
            {

                var rootObject = JsonConvert.DeserializeObject<RootObject>(json);

                this.childGrowth = new ObservableCollection<WHOChildGrowthStandards>(rootObject.data);
                return this.childGrowth;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
