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
        public CloudTable medrec;
        public AzureStore()
        {
            CloudStorageAccount myStorage = CloudStorageAccount.Parse(
                "DefaultEndpointsProtocol=https;AccountName=phrdevelop;AccountKey=OYFfULV+hclTWMC37yjIuubqHXTbLU3J5nLE3qaDf/qS72h/M7Hz/n2XKHc1TnufMPjp8yDJSeobJCWPsttVMA==;BlobEndpoint=https://phrdevelop.blob.core.windows.net/;TableEndpoint=https://phrdevelop.table.core.windows.net/;QueueEndpoint=https://phrdevelop.queue.core.windows.net/;FileEndpoint=https://phrdevelop.file.core.windows.net/");
            CloudTableClient myTable = myStorage.CreateCloudTableClient();
            table = myTable.GetTableReference("patient");
            table.CreateIfNotExists();
            medrec = myTable.GetTableReference("records");
            medrec.CreateIfNotExists();
        }
        public void AddPatient (PatientEntity entity)
        {
            TableOperation insertNew = TableOperation.Insert(entity);
            table.Execute(insertNew);
        }
        public void AddRecord (RecordEntity record)
        {
            if (record.PartitionKey == null)
            {
                TableBatchOperation batchOperation = new TableBatchOperation();
                batchOperation.Insert(record);
                medrec.ExecuteBatch(batchOperation);
            }
            //TableOperation insertRecord = TableOperation.Insert(record);
            //medrec.Execute(insertRecord);
        }

        public static object PatientEntity(string p)
        {
            throw new NotImplementedException();
        }

        public ITableEntity recordA { get; set; }

        public ITableEntity recordB { get; set; }
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

    public class RecordEntity : TableEntity
    {
        public RecordEntity (string id, string date)
        {
            this.PartitionKey = id;
            this.RowKey = date;
        }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
