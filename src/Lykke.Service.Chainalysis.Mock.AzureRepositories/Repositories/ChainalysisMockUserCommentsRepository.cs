using System.Threading.Tasks;
using AzureStorage;
using Lykke.Service.ChainalysisMock.AzureRepositories.Tables;
using Lykke.Service.ChainalysisMock.Core.Repositories;

namespace Lykke.Service.ChainalysisMock.AzureRepositories.Repositories
{
    public class ChainalysisMockUserCommentsRepository : IChainalysisMockUserCommentsRepository
    {
        private readonly INoSQLTableStorage<MockUserComment> _repository;
        public ChainalysisMockUserCommentsRepository(INoSQLTableStorage<MockUserComment> repository)
        {
            _repository = repository;
        }
        public async Task<string> GetUserCommentAsync(string token, string userId)
        {
            var item = await _repository.GetDataAsync(token, userId);
            return item?.Comment ?? string.Empty;
        }

        public async Task UpdateUserCommentAsync(string token, string userId, string userCommentComment)
        {
            await _repository.InsertOrMergeAsync(new MockUserComment
            {
                Token = token,
                UserId = userId,
                Comment = userCommentComment
            });
        }
    }
}
