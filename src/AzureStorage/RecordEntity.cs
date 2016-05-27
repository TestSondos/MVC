using Contracts;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorage
{
    public class RecordEntity : TableEntity, IMedicalRecord
    {
        public RecordEntity(string userId, string recordId=null)
        {
            this.PartitionKey = userId;
            this.RowKey = recordId ?? Guid.NewGuid().ToString("D");
        }

        public RecordEntity() 
        {
        }

        public string Type { get; set; }
        public string Json { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }

        public string UserID
        {
            get { return PartitionKey; }
            set { PartitionKey = value; }
        }

        public string RecordID
        {
            get { return RowKey; }
            set { RowKey = value; }
        }
    }
}
