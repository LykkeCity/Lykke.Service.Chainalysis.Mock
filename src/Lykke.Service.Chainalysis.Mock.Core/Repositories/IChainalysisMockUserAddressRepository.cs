using System.Threading.Tasks;
using Lykke.Service.ChainalysisMock.Core.Domain;

namespace Lykke.Service.ChainalysisMock.Core.Repositories
{
    public interface IChainalysisMockUserAddressRepository
    {
        Task DeleteDepositAddressAsync(string token, string userId, string address, bool isDeposits);
        Task<IUserDepositAddressInfo> GetUserDepositsAsync(string token, string userId);
        Task<IUserWithdrawAddressInfo> GetUserWithdrawAsync(string token, string userId);
        Task AddAddressAsync(string token, string userId, IAddressImport addressImport, bool isDeposit);
    }
}
