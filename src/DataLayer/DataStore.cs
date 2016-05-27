using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataStore
    {
        static Dictionary<string, List<string>> records = new Dictionary<string, List<string>>();

        static DataStore()
        {
            records.Add("b48f659d-6d5a-4a98-abed-1d4cd0a9966d", new List<string> { "A", "B", "C" });
        }


        public List<string> GetMedicalHistory(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return null;
            
            if (records.ContainsKey(id))
            {
                return records[id];
            }

            return null;
        }

        public void AddMedicalRecord(string id, string record)
        {
            if (string.IsNullOrWhiteSpace(id)) return;
            
            if (records.ContainsKey(id)==false)
            {
                records.Add(id, new List<string>());
            }

            records[id].Add(record);
        }
    }
}
