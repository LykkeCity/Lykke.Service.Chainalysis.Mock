using Lykke.Service.ChainalysisMock.Core.Domain;
using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Service.ChainalysisMock.AzureRepositories.Tables
{
    public class MockUserAddress : TableEntity
    {


        public MockUserAddress()
        {
            Name = "Test Name";
            Category = "Test Category";
            Score = "Test Score";
            ETag = "*";
        }

        public MockUserAddress(string token, string userId, IAddressImport addressImport, bool isDeposit)
        {
            UserTokenId = $"{token}:{userId}";
            IsDeposit = isDeposit ? 1 : 0;
            Address = addressImport.Address;
        }

        public string UserTokenId
        {
            get => PartitionKey;
            set => PartitionKey = value;
        }

        public string Address
        {
            get => RowKey;
            set => RowKey = value;
        }

        public long IsDeposit { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string Score { get; set; }
    }
}
