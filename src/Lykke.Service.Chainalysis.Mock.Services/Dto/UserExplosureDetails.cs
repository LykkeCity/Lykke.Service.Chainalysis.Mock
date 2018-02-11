using Lykke.Service.ChainalysisMock.Core.Domain;

namespace Lykke.Service.ChainalysisMock.Services.Dto
{
    public class UserExplosureDetails : IUserExplosureDetails
    {
        public UserExplosureDetails()
        {
            //This is Fake service!!

            Category = "Unknown";
            SentIndirectExposure = 10;
            SentDirectExposure = 10;
            ReceivedIndirectExposure = 10;
            ReceivedDirectExposure = 10;
        }


        public string Category { get; set; }
        public int SentIndirectExposure { get; set; }
        public int SentDirectExposure { get; set; }
        public int ReceivedIndirectExposure { get; set; }
        public int ReceivedDirectExposure { get; set; }
    }
}
