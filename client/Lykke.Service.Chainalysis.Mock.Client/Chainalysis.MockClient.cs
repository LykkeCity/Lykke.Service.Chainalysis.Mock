using System;
using System.Threading.Tasks;
using Common.Log;
using Lykke.Service.Chainalysis.Mock.Contracts;
using Lykke.Service.ChainalysisMock.Client.AutorestClient;
using AddressImportModel = Lykke.Service.ChainalysisMock.Client.AutorestClient.Models.AddressImportModel;
using CommentModel = Lykke.Service.ChainalysisMock.Client.AutorestClient.Models.CommentModel;
using OutputImportModel = Lykke.Service.ChainalysisMock.Client.AutorestClient.Models.OutputImportModel;
using UserImportModel = Lykke.Service.ChainalysisMock.Client.AutorestClient.Models.UserImportModel;

namespace Lykke.Service.ChainalysisMock.Client
{
    public class ChainalysisMockClient : IChainalysisMockClient, IDisposable
    {

        private IChainalysisRiskAPI _client; 

        public ChainalysisMockClient(string serviceUrl)
        {

            if (serviceUrl == null) throw new ArgumentNullException(nameof(serviceUrl));
            _client = new ChainalysisRiskAPI(new Uri(serviceUrl));
        }

        public void Dispose()
        {
            if (_client == null)
                return;
            _client.Dispose();
            _client = null;
        }

        public async Task<UserDepositAddressInfoModel> GetAddressesDepositAsync(string userId, string token, int? limit = null,
            int? offset = null)
        {
            var resutl =
                await _client.UserByUserIdAddressesDepositGetWithHttpMessagesAsync(userId, token, limit, offset);
            return resutl.Body.ToContract();
        }

        public async Task<object> AddAddressesDepositAsync(string userId, AddressImportModel depositeAddress,
            string token)
        {
            var resutl =
                await _client.UserByUserIdAddressesDepositPostWithHttpMessagesAsync(userId, depositeAddress, token);
            return resutl.Body;
        }

        public async Task<object> DeleteAddressesDepositAsync(string userId, string address, string token)
        {
            var resutl =
                await _client.UserByUserIdAddressesDepositByAddressDeleteWithHttpMessagesAsync(userId, address, token);
            return resutl.Body;
        }

        public async Task<UserTransactionInfoModel> GetOutputsReceivedAsync(string userId, string token, TransactionStatus? status = null,
            int? limit = null, int? offset = null)
        {
            var resutl =
                await _client.UserByUserIdOutputsReceivedGetWithHttpMessagesAsync(userId, token, status?.ToString(), limit, offset);
            return resutl.Body.ToContract();
        }

        public async Task<ReceiveOutputInfoModel> AddOutputsReceivedAsync(string userId, OutputImportModel output, string token)
        {
            var resutl =
                await _client.UserByUserIdOutputsReceivedPostWithHttpMessagesAsync(userId, output, token);
            return resutl.Body.ToContract();
        }

        public async Task<object> DeleteOutputsReceivedAsync(string userId, string tx, string output,
            string token)
        {
            var resutl =
                await _client.UserByUserIdOutputsReceivedByTxByOutputDeleteWithHttpMessagesAsync(userId, tx, output, token);
            return resutl.Body;
        }

        public async Task<UserTransactionInfoModel> GetOutputsSentAsync(string userId, string token, TransactionStatus? status = null,
            int? limit = null, int? offset = null)
        {
            var resutl =
                await _client.UserByUserIdOutputsSentGetWithHttpMessagesAsync(userId, token, status?.ToString(), limit, offset);
            return resutl.Body.ToContract();
        }

        public async Task<object> AddOutputsSentAsync(string userId, OutputImportModel output, string token)
        {
            var resutl =
                await _client.UserByUserIdOutputsSentPostWithHttpMessagesAsync(userId, output, token);
            return resutl.Body;
        }

        public async Task<object> DeleteOutputsSentAsync(string userId, string tx, string output,
            string token)
        {
            var resutl =
                await _client.UserByUserIdOutputsSentByTxByOutputDeleteWithHttpMessagesAsync(userId, tx, output, token);
            return resutl.Body;
        }

        public async Task<UserInfoModel> GetUsersAsync(string token, int? maxIdleDays = null, RiskScore? score = null, int? limit = null,
            int? offset = null)
        {
            var resutl =
                await _client.UserGetWithHttpMessagesAsync(token, maxIdleDays, score?.ToString(), limit, offset);
            return resutl.Body.ToContract();
        }

        public async Task<string> ImportUserAsync(UserImportModel userImport, string token)
        {
            var resutl =
                await _client.UserImportPostWithHttpMessagesAsync(userImport, token);
            return resutl.Body;
        }

        public async Task<UserDetailsModel> GetUserAsync(string userId, string token)
        {
            var resutl =
                await _client.UserByUserIdGetWithHttpMessagesAsync(userId, token);
            return resutl.Body.ToContract();
        }

        public async Task<object> UpdateUserCommentAsync(string userId, CommentModel comment, string token)
        {
            var resutl =
                await _client.UserByUserIdCommentPostWithHttpMessagesAsync(userId, comment, token);
            return resutl.Body;
        }

        public async Task<UserWithdrawAddressInfoModel> GetAddressesWithdrawalAsync(string userId, string token, int? limit = null,
            int? offset = null)
        {
            var resutl =
                await _client.UserByUserIdAddressesWithdrawalGetWithHttpMessagesAsync(userId, token, limit, offset);
            return resutl.Body.ToContract();
        }

        public async Task<WithdrawAddressInfoModel> AddAddressesWithdrawalAsync(string userId, AddressImportModel withdrawalAddress,
            string token)
        {
            var resutl =
                await _client.UserByUserIdAddressesWithdrawalPostWithHttpMessagesAsync(userId, withdrawalAddress, token);
            return resutl.Body.ToContract();
        }

        public async Task<object> DeleteAddressesWithdrawalAsync(string userId, string address, string token)
        {
            var resutl =
                await _client.UserByUserIdAddressesWithdrawalByAddressDeleteWithHttpMessagesAsync(userId, address, token);
            return resutl.Body;
        }
    }
}
