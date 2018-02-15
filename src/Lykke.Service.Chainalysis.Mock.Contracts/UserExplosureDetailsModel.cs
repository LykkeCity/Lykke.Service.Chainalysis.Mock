namespace Lykke.Service.Chainalysis.Mock.Contracts
{
    public class UserExplosureDetailsModel
    {
        public string Category { get; set; }

        public int SentIndirectExposure { get; set; }
        public int SentDirectExposure { get; set; }
        public int ReceivedIndirectExposure { get; set; }
        public int ReceivedDirectExposure { get; set; }
    }
}
