using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace ConsoleApplication
{
    public abstract class RecordEntity : TableEntity
    {
        public DateTime CreationTime { get; set; }
        public string UserId { get { return PartitionKey; } }
        public string RecordType { get { return RowKey.Substring(0, RowKey.LastIndexOf('_')); } }
        public string RecordId
        {
            get
            {
                var lastIndex = RowKey.LastIndexOf('_') + 1;
                return RowKey.Substring(lastIndex, RowKey.Length - lastIndex);
            }
        }
        public bool IsDeleted { get; set; }
    }
}