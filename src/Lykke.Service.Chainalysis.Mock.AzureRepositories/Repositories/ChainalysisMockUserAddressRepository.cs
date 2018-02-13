using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureStorage;
using Lykke.Service.ChainalysisMock.AzureRepositories.Dto;
using Lykke.Service.ChainalysisMock.AzureRepositories.Tables;
using Lykke.Service.ChainalysisMock.Core.Domain;
using Lykke.Service.ChainalysisMock.Core.Repositories;

namespace Lykke.Service.ChainalysisMock.AzureRepositories.Repositories
{
    public class ChainalysisMockUserAddressRepository : IChainalysisMockUserAddressRepository
    {
        private readonly INoSQLTableStorage<MockUserAddress> _repository;


        public ChainalysisMockUserAddressRepository(INoSQLTableStorage<MockUserAddress> repository)
        {
            _repository = repository;
        }


        private async Task<List<MockUserAddress>> GetUserAddresses(string token, string userId)
        {
            return (await _repository.GetDataAsync($"{token}:{userId}")).ToList();
        }


        public async Task DeleteDepositAddressAsync(string token, string userId, string address, bool isDeposits)
        {
            await _repository.DeleteIfExistAsync($"{token}:{userId}", address);
        }

        public async Task<IUserDepositAddressInfo> GetUserDepositsAsync(string token, string userId)
        {
            var addresses = await GetUserAddresses(token, userId);
            return new UserDepositAddressInfo(addresses.Where(a => a.IsDeposit == 1).Select(a => a.Address));
        }

        public async Task<IUserWithdrawAddressInfo> GetUserWithdrawAsync(string token, string userId)
        {
            var addresses = await GetUserAddresses(token, userId);
            return new UserWithdrawAddressInfo(addresses.Where(a => a.IsDeposit == 0).Select(a =>
                                            new WithdrawAddressInfo
                                            {
                                                Address = a.Address,
                                                Category = a.Category,
                                                Name = a.Name,
                                                Score = a.Score
                                            }));
        }

        public async Task AddAddressAsync(string token, string userId, IAddressImport addressImport, bool isDeposit)
        {
            var item = new MockUserAddress(token, userId, addressImport, isDeposit);
            await _repository.InsertOrMergeAsync(item);
        }
    }
}
