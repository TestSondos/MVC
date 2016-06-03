using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using medrecs.data.Core;

namespace medrecs.data
{
    public class BloodPressure : RecordEntity
    {
        public int Systolic { get; set; }
        public int Diastolic { get; set; }

        public string Category
        {
            // ref: http://www.heart.org/HEARTORG/Conditions/HighBloodPressure/AboutHighBloodPressure/Understanding-Blood-Pressure-Readings_UCM_301764_Article.jsp#.V0uoqZF97IU
            get { return string.Empty; }
        }
    }
}
