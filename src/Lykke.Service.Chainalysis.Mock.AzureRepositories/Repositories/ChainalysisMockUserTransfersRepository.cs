using System.Linq;
using System.Threading.Tasks;
using AzureStorage;
using Lykke.Service.ChainalysisMock.AzureRepositories.Dto;
using Lykke.Service.ChainalysisMock.AzureRepositories.Tables;
using Lykke.Service.ChainalysisMock.Core.Domain;
using Lykke.Service.ChainalysisMock.Core.Repositories;

namespace Lykke.Service.ChainalysisMock.AzureRepositories.Repositories
{
    public class ChainalysisMockUserTransfersRepository : IChainalysisMockUserTransfersRepository
    {
        private readonly INoSQLTableStorage<MockUserTransactions> _repository;
        public ChainalysisMockUserTransfersRepository(INoSQLTableStorage<MockUserTransactions> repository)
        {
            _repository = repository;
        }
        public async Task<IUserTransactionInfo> GetUserTransferAsync(string token, string userId, bool isReceive)
        {
            var items = await _repository.GetDataAsync($"{token}:{userId}");
            return new UserTransactionInfo(from item in items
                                           where item.IsReceive == (isReceive ? 1 : 0)
                                           select new TransactionInfo(item.Output, item.Status));
        }

        public async Task DeleteOutputSendAsync(string token, string userId, string transactionId, bool isReceive)
        {
            var item = await _repository.GetDataAsync($"{token}:{userId}", transactionId);
            if (item?.IsReceive == (isReceive ? 1 : 0))
            {
                await _repository.DeleteAsync(item);
            }

        }

        public async Task AddOutputAsync(string token, string userId, IOutputImport outputImport, bool isReceive)
        {
            await _repository.InsertOrMergeAsync(new MockUserTransactions
            {
                UserTokenId = $"{token}:{userId}",
                Output = outputImport.Output,
                Status = "green",
                IsReceive = isReceive ? 1 : 0
            });
        }
    }
}
