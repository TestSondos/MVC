using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medrecs.data.Core
{
    internal static class MedrecsConfigurationManager
    {
        private static CloudStorageAccount GetCloudStorageAccount(string configKey)
        {
            var connectionString = CloudConfigurationManager.GetSetting(configKey);
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            return storageAccount;
        }

        private static CloudTable GetCloudTable(CloudStorageAccount storageAccount, string tableName)
        {
            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference(tableName);
            table.CreateIfNotExists();
            return table;
        }


        private static CloudStorageAccount MetadataStorage { get { return GetCloudStorageAccount("medrecsMetadataStorage"); } }
        private static CloudStorageAccount DataStorage { get { return GetCloudStorageAccount("medrecsDataStorage"); } }

        private readonly static Lazy<CloudTable> _recordsTable = new Lazy<CloudTable>(() =>
        {
            return GetCloudTable(MetadataStorage, "records");
        });

        internal static CloudTable RecordsTable { get { return _recordsTable.Value; } }
    }
}
