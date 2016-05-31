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

        public IEnumerable<IMedicalRecord> ReadAll(string userId)
        {
            TableQuery<RecordEntity> query = new TableQuery<RecordEntity>
                ().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, userId));
            return query;
        //    var query = new TableQuery<RecordEntity>().
        //        Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, userId));

        //    var queryResult = recordsTable.ExecuteQuery<RecordEntity>(query);

        //    return queryResult.Select<RecordEntity, IMedicalRecord>(record => record as IMedicalRecord);
        }


        public IEnumerable<IMedicalRecord> ReadAll(string userId, int pageNumber)
        {
            throw new NotImplementedException();
        }
    }
}
