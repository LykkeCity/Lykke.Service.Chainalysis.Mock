using System.Threading.Tasks;

namespace Lykke.Service.ChainalysisMock.Core.Repositories
{
    public interface IChainalysisMockUserCommentsRepository
    {
        Task<string> GetUserCommentAsync(string token, string userId);
        Task UpdateUserCommentAsync(string token, string userId, string userCommentComment);
    }
}
