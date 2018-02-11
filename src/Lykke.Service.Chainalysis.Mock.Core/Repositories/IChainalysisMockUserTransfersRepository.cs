using System.Threading.Tasks;
using Lykke.Service.ChainalysisMock.Core.Domain;

namespace Lykke.Service.ChainalysisMock.Core.Repositories
{
    public interface IChainalysisMockUserTransfersRepository
    {
        Task<IUserTransactionInfo> GetUserTransferAsync(string token, string userId, bool isReceive);
        Task DeleteOutputSendAsync(string token, string userId, string transactionId, bool isReceive);
        Task AddOutputAsync(string token, string userId, IOutputImport outputImport, bool isReceive);
    }
}
