using System.Threading.Tasks;
using Lykke.Service.ChainalysisMock.Core.Domain;

namespace Lykke.Service.ChainalysisMock.Core.Repositories
{
    public interface IChainalysisMockUserRepository
    {
        Task<IUserRepoInfo> GetUsersAsync(string token);
        Task UpdateUserAsync(string token, IUserImport userImport);
    }
}
