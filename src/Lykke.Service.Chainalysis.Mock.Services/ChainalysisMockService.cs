using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lykke.Service.ChainalysisMock.Core.Domain;
using Lykke.Service.ChainalysisMock.Core.Repositories;
using Lykke.Service.ChainalysisMock.Core.Services;
using Lykke.Service.ChainalysisMock.Services.Dto;

namespace Lykke.Service.ChainalysisMock.Services
{
    public class ChainalysisMockService : IChainalysisMockService
    {
        private readonly IChainalysisMockUserRepository _chainalysisMockUserRepository;
        private readonly IChainalysisMockUserCommentsRepository _chainalysisMockUserCommentsRepository;
        private readonly IChainalysisMockUserAddressRepository _chainalysisMockUserAddressRepository;
        private readonly IChainalysisMockUserTransfersRepository _chainalysisMockUserTransfersRepository;

        public ChainalysisMockService(
            IChainalysisMockUserRepository chainalysisMockUserRepository,
            IChainalysisMockUserAddressRepository chainalysisMockUserAddressRepository,
            IChainalysisMockUserTransfersRepository chainalysisMockUserTransfersRepository,
            IChainalysisMockUserCommentsRepository chainalysisMockUserCommentsRepository)
        {
            _chainalysisMockUserRepository = chainalysisMockUserRepository;
            _chainalysisMockUserAddressRepository = chainalysisMockUserAddressRepository;
            _chainalysisMockUserTransfersRepository = chainalysisMockUserTransfersRepository;
            _chainalysisMockUserCommentsRepository = chainalysisMockUserCommentsRepository;
        }

        public async Task<IUserInfo> GetUsersAsync(string token, int? maxIdleDays, RiskScore? score, int? limit, int? offset)
        {
            var result = await _chainalysisMockUserRepository.GetUsersAsync(token);
            IEnumerable<IUserRepoData> userData = result.Data;
            if (maxIdleDays.HasValue)
            {
                userData = userData.Where(ud => ud.LastActivity >= maxIdleDays);
            }
            if (score.HasValue)
            {
                userData = userData.Where(ud => ud.Score.Equals(score.ToString()));
            }
            if (offset.HasValue)
            {
                userData = userData.Skip(offset.Value);
            }
            if (limit.HasValue)
            {
                userData = userData.Take(limit.Value);
            }

            return new UserInfo(result, userData);
        }

        public async Task ImportUserAsync(string token, IUserImport userImport)
        {
            await _chainalysisMockUserRepository.UpdateUserAsync(token, userImport);
        }

        public async Task<IUserDetails> GetUserAsync(string token, string userId)
        {
            var result = await _chainalysisMockUserRepository.GetUsersAsync(token);
            var userData = result.Data.FirstOrDefault(ud => ud.UserId.Equals(userId));

            if (userData == null)
            {
                return null;
            }

            return new UserDetails
            {
                Score = userData.Score,
                Comment = await _chainalysisMockUserCommentsRepository.GetUserCommentAsync(token, userId),
                CreationDate = userData.CreatedDate,
                LastActivity = userData.LastActivity,
                ScoreUpdatedDate = userData.ScoreUpdatedDate,
                UserId = userData.UserId
            };
        }

        public async Task UpdateUserCommentAsync(string token, string userId, IUserComment userComment)
        {
            await _chainalysisMockUserCommentsRepository.UpdateUserCommentAsync(token, userId, userComment.Comment);
        }

        public async Task<IUserDepositAddressInfo> GetUserDepositsAsync(string token, string userId, int? limit, int? offset)
        {
            var result = await _chainalysisMockUserAddressRepository.GetUserDepositsAsync(token, userId);
            IEnumerable<IAddressInfo> addressData = result.Data;
            if (offset.HasValue)
            {
                addressData = addressData.Skip(offset.Value);
            }
            if (limit.HasValue)
            {
                addressData = addressData.Take(limit.Value);
            }
            result.Data = addressData.ToList();
            return result;
        }

        public async Task<IAddressInfo> AddAddressDepositsAsync(string token, string userId, IAddressImport addressImport)
        {
            await CreateUserIfNotExists(token, userId);
            await _chainalysisMockUserAddressRepository.AddAddressAsync(token, userId, addressImport, true);
            return new AddressInfo
            {
                Address = addressImport.Address
            };
        }

        public async Task<object> DeleteDepositAddressAsync(string token, string userId, string address)
        {
            await _chainalysisMockUserAddressRepository.DeleteDepositAddressAsync(token, userId, address, true);
            return new object();
        }

        public async Task<IUserWithdrawAddressInfo> GetUserWithdrawAsync(string token, string userId, int? limit, int? offset)
        {
            var result = await _chainalysisMockUserAddressRepository.GetUserWithdrawAsync(token, userId);
            IEnumerable<IWithdrawAddressInfo> addressData = result.Data;
            if (offset.HasValue)
            {
                addressData = addressData.Skip(offset.Value);
            }
            if (limit.HasValue)
            {
                addressData = addressData.Take(limit.Value);
            }
            result.Data = addressData.ToList();
            return result;
        }

        public async Task<IWithdrawAddressInfo> AddAddressWithdrawAsync(string token, string userId, IAddressImport addressImport)
        {
            await CreateUserIfNotExists(token, userId);
            await _chainalysisMockUserAddressRepository.AddAddressAsync(token, userId, addressImport, false);
            return new WithdrawAddressInfo
            {
                Address = addressImport.Address,
                Score = RiskScore.Green.ToString(),
                Category = "Test Category",
                Name = "Test Name"
            };
        }

        public async Task<object> DeleteWithdrawalAsync(string token, string userId, string address)
        {
            await _chainalysisMockUserAddressRepository.DeleteDepositAddressAsync(token, userId, address, false);
            return new object();
        }

        public async Task<IUserTransactionInfo> GetUserOutputsSendsAsync(string token, string userId, TransactionStatus? transactionStatus, int? limit, int? offset)
        {
            var result = await _chainalysisMockUserTransfersRepository.GetUserTransferAsync(token, userId, false);
            IEnumerable<ITransactionInfo> data = result.Data;
            if (transactionStatus.HasValue)
            {
                data = data.Where(d => transactionStatus.ToString().Equals(d.Status));
            }
            if (offset.HasValue)
            {
                data = data.Skip(offset.Value);
            }
            if (limit.HasValue)
            {
                data = data.Take(limit.Value);
            }
            result.Data = data.ToList();
            return result;
        }

        public async Task<object> AddOutputSendsAsync(string token, string userId, IOutputImport outputImport)
        {
            await CreateUserIfNotExists(token, userId);
            await _chainalysisMockUserTransfersRepository.AddOutputAsync(token, userId, outputImport, false);
            return new object();
        }

        public async Task<object> DeleteOutputSendAsync(string token, string userId, string tx, string output)
        {
            await _chainalysisMockUserTransfersRepository.DeleteOutputSendAsync(token, userId, $"{tx}:{output}", false);
            return new object();
        }

        public async Task<IUserTransactionInfo> GetUserOutputsReceivedAsync(string token, string userId, TransactionStatus? status, int? limit, int? offset)
        {
            var result = await _chainalysisMockUserTransfersRepository.GetUserTransferAsync(token, userId, true);
            IEnumerable<ITransactionInfo> data = result.Data;
            if (status.HasValue)
            {
                data = data.Where(d => status.ToString().Equals(d.Status));
            }
            if (offset.HasValue)
            {
                data = data.Skip(offset.Value);
            }
            if (limit.HasValue)
            {
                data = data.Take(limit.Value);
            }
            result.Data = data.ToList();
            return result;
        }

        public async Task<IReceiveOutputInfo> AddOutputReceivesAsync(string token, string userId, IOutputImport outputs)
        {
            await CreateUserIfNotExists(token, userId);
            await _chainalysisMockUserTransfersRepository.AddOutputAsync(token, userId, outputs, true);
            return new ReceiveOutputInfo
            {
                Score = RiskScore.Green.ToString(),
                Category = "Test Category",
                Name = "Test Name"
            };
        }

        public async Task<object> DeleteOutputReceiveAsync(string token, string userId, string tx, string output)
        {
            await _chainalysisMockUserTransfersRepository.DeleteOutputSendAsync(token, userId, $"{tx}:{output}", false);
            return new object();
        }

        private async Task CreateUserIfNotExists(string token, string userId)
        {
            var users = await _chainalysisMockUserRepository.GetUsersAsync(token);
            if (users.Data.All(u=>!u.UserId.Equals(userId)))
            {
                await _chainalysisMockUserRepository.UpdateUserAsync(token, new UserImport
                {
                    UserId = userId
                });
            }
        }
    }
}
