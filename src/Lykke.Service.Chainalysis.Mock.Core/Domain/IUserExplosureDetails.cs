namespace Lykke.Service.ChainalysisMock.Core.Domain
{
    public interface IUserExplosureDetails
    {
        string Category { get; set; }

        int SentIndirectExposure { get; set; }
        int SentDirectExposure { get; set; }
        int ReceivedIndirectExposure { get; set; }
        int ReceivedDirectExposure { get; set; }
    }
}
