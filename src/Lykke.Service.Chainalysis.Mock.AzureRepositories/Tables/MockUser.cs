using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Service.ChainalysisMock.AzureRepositories.Tables
{
    public class MockUser : TableEntity
    {
        public MockUser()
        {
            ETag = "*";
        }

        public string Token
        {
            get => PartitionKey;
            set => PartitionKey = value;
        }

        public string UserId
        {
            get => RowKey;
            set => RowKey = value;
        }
        public long LastActivity { get; set; }
        public string Score { get; set; }
        public long ScoreUpdatedDate { get; set; }
        public long CreatedDate { get; set; }
    }
}
