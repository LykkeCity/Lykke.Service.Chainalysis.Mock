using Lykke.Service.ChainalysisMock.Core.Settings.ServiceSettings;
using Lykke.Service.ChainalysisMock.Core.Settings.SlackNotifications;

namespace Lykke.Service.ChainalysisMock.Core.Settings
{
    public class AppSettings
    {
        public ChainalysisMockSettings ChainalysisMockService { get; set; }
        public SlackNotificationsSettings SlackNotifications { get; set; }
    }
}
