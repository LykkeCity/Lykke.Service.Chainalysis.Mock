using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Lykke.Service.ChainalysisMock.Core.Domain;

namespace Lykke.Service.ChainalysisMock.Core.Services
{
    public interface IChainalysisMockService
    {
        Task<IUserInfo> GetUsersAsync(string token, int? maxIdleDays, RiskScore? score, int? limit, int? offset);
        Task ImportUserAsync(string token, IUserImport userImport);
        Task<IUserDetails> GetUserAsync(string token, string userId);
        Task UpdateUserCommentAsync(string token, string userId, IUserComment userComment);
        Task<IUserDepositAddressInfo> GetUserDepositsAsync(string token, string userId, int? limit, int? offset);
        Task<IAddressInfo> AddAddressDepositsAsync(string token, string userId, IAddressImport addressImport);
        Task<object> DeleteDepositAddressAsync(string token, string userId, string address);
        Task<IUserWithdrawAddressInfo> GetUserWithdrawAsync(string token, string userId, int? limit, int? offset);
        Task<IWithdrawAddressInfo> AddAddressWithdrawAsync(string token, string userId, IAddressImport addressImport);
        Task<object> DeleteWithdrawalAsync(string token, string userId, string address);
        Task<IUserTransactionInfo> GetUserOutputsSendsAsync(string token, string userId, TransactionStatus? transactionStatus, int? limit, int? offset);
        Task<object> AddOutputSendsAsync(string token, string userId, IOutputImport outputImport);
        Task<object> DeleteOutputSendAsync(string token, string userId, string tx, string output);
        Task<IUserTransactionInfo> GetUserOutputsReceivedAsync(string token, string userId, TransactionStatus? status, int? limit, int? offset);
        Task<IReceiveOutputInfo> AddOutputReceivesAsync(string token, string userId, IOutputImport outputs);
        Task<object> DeleteOutputReceiveAsync(string token, string userId, string tx, string output);
    }
}
