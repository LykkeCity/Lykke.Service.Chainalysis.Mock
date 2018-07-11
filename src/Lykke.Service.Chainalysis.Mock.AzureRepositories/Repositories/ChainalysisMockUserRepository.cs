using System;
using System.Linq;
using System.Threading.Tasks;
using AzureStorage;
using Lykke.Service.ChainalysisMock.AzureRepositories.Dto;
using Lykke.Service.ChainalysisMock.AzureRepositories.Tables;
using Lykke.Service.ChainalysisMock.Core.Domain;
using Lykke.Service.ChainalysisMock.Core.Repositories;

namespace Lykke.Service.ChainalysisMock.AzureRepositories.Repositories
{
    public class ChainalysisMockUserRepository : IChainalysisMockUserRepository
    {
        private readonly INoSQLTableStorage<MockUser> _repository;
        private readonly IChainalysisMockUserAddressRepository _addressRepo;
        private readonly IChainalysisMockUserTransfersRepository _transfersRepo;
        public ChainalysisMockUserRepository(INoSQLTableStorage<MockUser> repository,
            IChainalysisMockUserAddressRepository addressRepo,
            IChainalysisMockUserTransfersRepository transfersRepo)
        {
            _repository = repository;
            _addressRepo = addressRepo;
            _transfersRepo = transfersRepo;
        }
        private readonly static DateTime StartDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        public async Task<IUserRepoInfo> GetUsersAsync(string token)
        {
            
            var users = await _repository.GetDataAsync(token);
            return new UserRepoInfo(from user in users
                                    select new UserRepoData
                                    {
                                       UserId = user.UserId,
                                       Score = user.Score,
                                       CreatedDate = (long)(DateTime.UtcNow - StartDate).TotalSeconds,
                                       LastActivity = user.LastActivity,
                                       ScoreUpdatedDate = user.ScoreUpdatedDate
                                    });

        }

        public async Task UpdateUserAsync(string token, IUserImport userImport)
        {
            await _repository.InsertOrMergeAsync(new MockUser
            {
                Token = token,
                UserId = userImport.UserId,
                LastActivity = 0,
                Score = "green",
                ScoreUpdatedDate = 0,
                CreatedDate = 0
            });

            if (userImport.DepositAddresses != null)
            {
                foreach (var address in userImport.DepositAddresses)
                {
                    await _addressRepo.AddAddressAsync(token, userImport.UserId, new AddressImport(address), true);
                }

            }

            if (userImport.WithdrawalAddresses != null)
            {
                foreach (var address in userImport.WithdrawalAddresses)
                {
                    await _addressRepo.AddAddressAsync(token, userImport.UserId, new AddressImport(address), false);
                }

            }

            if (userImport.ReceivedOutputs != null)
            {
                foreach (var outputs in userImport.ReceivedOutputs)
                {
                    await _transfersRepo.AddOutputAsync(token, userImport.UserId, new OutputImport(outputs), true);
                }
            }

            if (userImport.SentOutputs != null)
            {
                foreach (var outputs in userImport.SentOutputs)
                {
                    await _transfersRepo.AddOutputAsync(token, userImport.UserId, new OutputImport(outputs), false);
                }
            }
        }
    }
}
