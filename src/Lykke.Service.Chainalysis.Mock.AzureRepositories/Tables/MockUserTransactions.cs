using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Service.ChainalysisMock.AzureRepositories.Tables
{
    public class MockUserTransactions : TableEntity
    {
        public MockUserTransactions()
        {
            ETag = "*";
        }
        public string UserTokenId
        {
            get => PartitionKey;
            set => PartitionKey = value;
        }

        public string Output
        {
            get => RowKey;
            set => RowKey = value;
        }

        public int IsReceive { get; set; }
        public string Status { get; set; }
    }
}
