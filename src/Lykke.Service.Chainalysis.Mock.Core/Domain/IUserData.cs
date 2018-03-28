namespace Lykke.Service.ChainalysisMock.Core.Domain
{
    public interface IUserData
    {
        string UserId { get; set; }
        long LastActivity { get; set; }
        string Score { get; set; }
        long ScoreUpdatedDate { get; set; }

    }
}
