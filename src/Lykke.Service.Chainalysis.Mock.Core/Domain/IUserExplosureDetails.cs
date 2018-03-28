namespace Lykke.Service.ChainalysisMock.Core.Domain
{
    public interface IUserExplosureDetails
    {
        string Category { get; set; }

        long SentIndirectExposure { get; set; }
        long SentDirectExposure { get; set; }
        long ReceivedIndirectExposure { get; set; }
        long ReceivedDirectExposure { get; set; }
    }
}
