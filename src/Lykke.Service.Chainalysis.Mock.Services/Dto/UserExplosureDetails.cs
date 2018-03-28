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
        public long SentIndirectExposure { get; set; }
        public long SentDirectExposure { get; set; }
        public long ReceivedIndirectExposure { get; set; }
        public long ReceivedDirectExposure { get; set; }
    }
}
