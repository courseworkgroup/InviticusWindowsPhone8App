using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inviticus.Model;


namespace Inviticus
{
    public class BabyDataContext : DataContext
    {

        // Specify a single table for the to-do items.
        public Table<Baby> Babies;
        public Table<Weight> Weights;

        // Specify the connection string as a static, used in main page and app.xaml.
        public static string DBConnectionString = "Data Source=isostore:/Babies.sdf";

        // Pass the connection string to the base class.
        public BabyDataContext(string connectionString) : base(connectionString)
        {
            this.Babies = this.GetTable<Baby>();
            this.Weights = this.GetTable<Weight>();
        }

    }
}
