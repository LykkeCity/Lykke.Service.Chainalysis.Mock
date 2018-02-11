using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Lykke.Service.ChainalysisMock.Core.Domain;
using Lykke.Service.ChainalysisMock.Core.Services;

namespace Lykke.Service.ChainalysisMock.Services
{
    public class ChainalysisMockService : IChainalysisMockService
    {
        public ChainalysisMockService()
        {
            
        }

        public async Task<IUserInfo> GetUsersAsync(string token, int? maxIdleDays, RiskScore? score, int? limit, int? offset)
        {
            throw new NotImplementedException();
        }

        public async Task ImportUserAsync(string token, IUserImport map)
        {
            throw new NotImplementedException();
        }

        public async Task<IUserDetails> GetUserAsync(string token, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUserCommentAsync(string token, IUserComment userComment)
        {
            throw new NotImplementedException();
        }

        public async Task<IUserDepositAddressInfo> GetUserDepositsAsync(string token, string userId, int? limit, int? offset)
        {
            throw new NotImplementedException();
        }

        public async Task<IAddressInfo> AddAddressDepositsAsync(string token, string userId, IAddressImport addressImport)
        {
            throw new NotImplementedException();
        }

        public async Task<object> DeleteDepositAddressAsync(string token, string userId, string address)
        {
            throw new NotImplementedException();
        }

        public async Task<IUserWindrowAddressInfo> GetUserWithdrawAsync(string token, string userId, int? limit, int? offset)
        {
            throw new NotImplementedException();
        }

        public async Task<IWindrowAddressInfo> AddAddressWithdrawAsync(string token, string userId, IAddressImport map)
        {
            throw new NotImplementedException();
        }

        public async Task<object> DeleteWithdrawalAsync(string token, string userId, string address)
        {
            throw new NotImplementedException();
        }

        public async Task<IUserTransactionInfo> GetUserOutputsSendsAsync(string token, string userId, TransactionStatus? map, int? limit, int? offset)
        {
            throw new NotImplementedException();
        }

        public async Task<object> AddOutputSendsAsync(string token, string userId, IOutputImport outputImport)
        {
            throw new NotImplementedException();
        }

        public async Task<object> DeleteOutputSendAsync(string token, string userId, string tx, string output)
        {
            throw new NotImplementedException();
        }

        public async Task<IUserTransactionInfo> GetUserOutputsReceivedAsync(string token, string userId, TransactionStatus? status, int? limit, int? offset)
        {
            throw new NotImplementedException();
        }

        public async Task<IReceiveOutputInfo> AddOutputReceivesAsync(string token, string userId, IOutputImport outputs)
        {
            throw new NotImplementedException();
        }

        public async Task<object> DeleteOutputReceiveAsync(string token, string userId, string tx, string output)
        {
            throw new NotImplementedException();
        }
    }
}
