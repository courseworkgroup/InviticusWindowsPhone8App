using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviticus.Model
{
    public class WHOChildGrowthStandards
    {
        public int Month { get; set; }
        public double L { get; set; }
        public double M { get; set; }
        public double S { get; set; }
        public double P01 { get; set; }
        public double P1 { get; set; }
        public double P3 { get; set; }
        public double P5 { get; set; }
        public double P10 { get; set; }
        public double P15 { get; set; }
        public double P25 { get; set; }
        public double P50 { get; set; }
        public double P75 { get; set; }
        public double P85 { get; set; }
        public double P90 { get; set; }
        public double P95 { get; set; }
        public double P97 { get; set; }
        public double P99 { get; set; }
        public double P999 { get; set; }
    }

    public class RootObject
    {
        public List<WHOChildGrowthStandards> data { get; set; }
    }

}