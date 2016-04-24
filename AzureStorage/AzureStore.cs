using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using Contracts;

namespace AzureStorage
{
    public class AzureStore : IRecordsManager
    {
        public CloudTable recordsTable;
        public AzureStore()
        {
            CloudStorageAccount myStorage = CloudStorageAccount.Parse(
                "DefaultEndpointsProtocol=https;AccountName=phrdevelop;AccountKey=OYFfULV+hclTWMC37yjIuubqHXTbLU3J5nLE3qaDf/qS72h/M7Hz/n2XKHc1TnufMPjp8yDJSeobJCWPsttVMA==;BlobEndpoint=https://phrdevelop.blob.core.windows.net/;TableEndpoint=https://phrdevelop.table.core.windows.net/;QueueEndpoint=https://phrdevelop.queue.core.windows.net/;FileEndpoint=https://phrdevelop.file.core.windows.net/");

            //CloudStorageAccount myStorage = CloudStorageAccount.DevelopmentStorageAccount;

            CloudTableClient tableClient = myStorage.CreateCloudTableClient();
            recordsTable = tableClient.GetTableReference("records");
            recordsTable.CreateIfNotExists();
        }

        public string Add(IMedicalRecord record)
        {
            var entity = record as RecordEntity;
            var operation = TableOperation.Insert(entity);
            recordsTable.Execute(operation);

            return entity.RecordID;
        }

        public void Update(IMedicalRecord updatedRecord)
        {
            var updatedEntity = updatedRecord as RecordEntity;
            updatedEntity.ETag = "*";
            var operation = TableOperation.Merge(updatedEntity);
            recordsTable.Execute(operation);
        }

        public IMedicalRecord Read(string userId)
        {
            TableOperation operation = TableOperation.Retrieve<RecordEntity>("Blood Pressure", DateTime.UtcNow.ToString());
            TableResult retrievedResult = recordsTable.Execute(operation);

            if (retrievedResult.Result != null)
                return retrievedResult.Result as IMedicalRecord;
            else
                return null;

        }

        public IEnumerable<IMedicalRecord> ReadBP (string userId)
        {
            TableQuery<RecordEntity> rangeQuery = new TableQuery<RecordEntity>().Where(
                TableQuery.CombineFilters(
                TableQuery.GenerateFilterCondition("Title", QueryComparisons.Equal, "Blood Pressure"),
                TableOperators.Or,
                TableQuery.GenerateFilterCondition("Title", QueryComparisons.Equal, "Sugar Level")));

                //TableOperators.And,
                //TableQuery.GenerateFilterCondition("Timestamp", QueryComparisons.LessThan, DateTime.UtcNow.AddHours(-DateTime.UtcNow.Hour).ToString())));

            //TableQuery<RecordEntity> rangeQuery = new TableQuery<RecordEntity>().Where(
            //    TableQuery.GenerateFilterCondition("Title", QueryComparisons.Equal, "Blood Pressure"));

            var queryResult = recordsTable.ExecuteQuery<RecordEntity>(rangeQuery);

            return queryResult.Select<RecordEntity, IMedicalRecord>(record => record as IMedicalRecord);
        }

        public IEnumerable<IMedicalRecord> ReadAll(string userId)
        {
            var query = new TableQuery<RecordEntity>().
                Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, userId));

            var queryResult = recordsTable.ExecuteQuery<RecordEntity>(query);

            return queryResult.Select<RecordEntity, IMedicalRecord>(record => record as IMedicalRecord);
        }

        public IEnumerable<IMedicalRecord> ReadAll(string userId, int pageNumber)
        {
            throw new NotImplementedException();
        }
    }
}
