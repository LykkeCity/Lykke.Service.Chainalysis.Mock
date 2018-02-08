using System.Threading.Tasks;

namespace Lykke.Service.ChainalysisMock.Core.Services
{
    public interface IShutdownManager
    {
        Task StopAsync();
    }
}
