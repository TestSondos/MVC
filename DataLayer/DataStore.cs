using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataStore
    {
        public List<string> GetMedicalHistory(string id)
        {
            switch (id)
            {
                case "b48f659d-6d5a-4a98-abed-1d4cd0a9966d":
                    return new List<string> { "A", "B", "C" };
                default:
                    return new List<string> { "No Medical History" };
            }
        }
    }
}
