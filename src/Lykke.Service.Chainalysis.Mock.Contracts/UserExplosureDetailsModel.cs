namespace Lykke.Service.Chainalysis.Mock.Contracts
{
    public class UserExplosureDetailsModel
    {
        public string Category { get; set; }

        public long SentIndirectExposure { get; set; }
        public long SentDirectExposure { get; set; }
        public long ReceivedIndirectExposure { get; set; }
        public long ReceivedDirectExposure { get; set; }
    }
}
