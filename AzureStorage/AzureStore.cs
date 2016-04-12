using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureStorage
{
    public class AzureStore
    {
        public CloudTable table;
        public AzureStore()
        {
            CloudStorageAccount myStorage = CloudStorageAccount.DevelopmentStorageAccount;
            CloudTableClient myTable = myStorage.CreateCloudTableClient();
            table = myTable.GetTableReference("AllPatients");
            table.CreateIfNotExists();
        }
        public void AddPatient (PatientEntity entity)
        {
            TableOperation insertNew = TableOperation.Insert(entity);
            table.Execute(insertNew);
        }

        public static object PatientEntity(string p)
        {
            throw new NotImplementedException();
        }
    }

    public class PatientEntity : TableEntity
    {
        public PatientEntity (string id, string date)
        {
            this.PartitionKey = id;
            this.RowKey = date;
        }

        public PatientEntity()
        {
            // TODO: Complete member initialization
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Mobile { get; set; }
        public string Email { get; set; }
    }
}
