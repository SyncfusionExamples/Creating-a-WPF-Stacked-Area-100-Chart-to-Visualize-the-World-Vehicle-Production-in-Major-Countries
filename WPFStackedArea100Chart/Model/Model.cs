using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace WPFStackedArea100Chart
{
    public class Model
    {
        public string Year { get; set; }
        public double BrazilValue { get; set; }
        public double ChinaValue { get; set; }
        public double GermanyValue { get; set; }
        public double IndiaValue { get; set; }
        public double JapanValue { get; set; }
        public double UKValue { get; set; }
        public double USAValue { get; set; }

        public Model(string category, double brazil, double china, double germany, double india, double japan, double uk, double usa)
        {
            Year = category;
            BrazilValue = brazil;
            ChinaValue = china;
            GermanyValue = germany;
            IndiaValue = india;
            JapanValue = japan;
            UKValue = uk;
            USAValue = usa;
        }
    }
}
