using System;
using System.Collections.Generic;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace ConsoleApplication
{
    public class RecordsManager
    {
        #region Cloud Table
        readonly Lazy<CloudTable> _recordsTable = new Lazy<CloudTable>(() =>
        {
            var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference("medrecs");
            table.CreateIfNotExists();
            return table;
        });

        CloudTable Table { get { return _recordsTable.Value; } }
        #endregion

        #region Insert
        private void SetupEntityBeforeInsert<T>(string userId, T entity) where T : RecordEntity
        {
            entity.PartitionKey = userId;
            entity.RowKey = string.Format("{0}_{1}", entity.GetType().Name, Guid.NewGuid().ToString("N"));
            entity.CreationTime = DateTime.UtcNow;
        }

        public void Insert<T>(string userId, T entity) where T : RecordEntity
        {
            SetupEntityBeforeInsert(userId, entity);
            Table.Execute(TableOperation.Insert(entity));
        }

        public void BulkInsert<T>(string userId, IEnumerable<T> entities) where T : RecordEntity
        {
            var batchOperation = new TableBatchOperation();

            foreach (var entity in entities)
            {
                SetupEntityBeforeInsert(userId, entity);
                batchOperation.Insert(entity);
            }

            Table.ExecuteBatch(batchOperation);
        }
        #endregion

        #region Read
        public IEnumerable<T> GetAll<T>(string userId, bool getDeleted = false) where T : RecordEntity, new()
        {
            var typeName = typeof(T).Name;
            var startRowKeyFilter = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.GreaterThanOrEqual, typeName + "_");
            var endRowKeyFilter = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.LessThan, typeName + (char)('_' + 1));
            var rowKeyFilter = TableQuery.CombineFilters(startRowKeyFilter, TableOperators.And, endRowKeyFilter);
            var partitionKeyFilter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, userId);
            var typeFilter = TableQuery.CombineFilters(partitionKeyFilter, TableOperators.And, rowKeyFilter);
            var finalFilter = typeFilter;
            if (getDeleted == false)
            {
                var notDeleted = TableQuery.GenerateFilterConditionForBool("IsDeleted", QueryComparisons.Equal, false);
                finalFilter = TableQuery.CombineFilters(finalFilter, TableOperators.And, notDeleted);
            }

            var rangeQuery = new TableQuery<T>().Where(finalFilter);
            return Table.ExecuteQuery(rangeQuery);
        }

        public IEnumerable<DynamicTableEntity> GetAll(string userId, bool getDeleted = false)
        {
            var partitionKeyFilter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, userId);
            var finalFilter = partitionKeyFilter;
            if (getDeleted == false)
            {
                var notDeleted = TableQuery.GenerateFilterConditionForBool("IsDeleted", QueryComparisons.Equal, false);
                finalFilter = TableQuery.CombineFilters(finalFilter, TableOperators.And, notDeleted);
            }

            var rangeQuery = new TableQuery<DynamicTableEntity>().Where(finalFilter);
            return Table.ExecuteQuery(rangeQuery);
        }
        #endregion

        #region Update
        public T Update<T>(T entity) where T : RecordEntity, new()
        {
            var tableResult = Table.Execute(TableOperation.Merge(entity));
            return tableResult.Result as T;
        }

        public void Delete<T>(T entity) where T : RecordEntity, new()
        {
            entity.IsDeleted = true;
            entity.ETag = "*";
            Table.Execute(TableOperation.Merge(entity));
        }
        #endregion
    }
}