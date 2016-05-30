using System.Globalization;
using System;
using System.Linq;
using _360Courier.Extensions;


namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var userId = "70165FFC-A154-4249-865F-702765D101CC";
            var recordsManager = new RecordsManager();

            #region Insert
            //recordsManager.Insert(userId, new BloodPressure
            //{
            //    Systolic = 120,
            //    Diastolic = 80
            //});
            //recordsManager.BulkInsert(userId, new RecordEntity[] {
            //    new BloodPressure {Systolic = 134, Diastolic = 85},
            //    new Weight {Value = 80},
            //    new RespiratoryRate {Value = 19}, 
            //    new Pulse {Value = 93}, 
            //    new Temperature{Value = 27.5}, 
            //});
            #endregion

            var all = recordsManager.GetAll<Pulse>(userId).ToArray();
            foreach (var entity in all)
            {
                Console.WriteLine(entity.ToJson(true));
            }
        }
    }
}
