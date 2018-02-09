namespace Lykke.Service.ChainalysisMock.Core.Domain
{
    public interface IUserData
    {
        string UserId { get; set; }
        int LastActivity { get; set; }
        string Score { get; set; }
        int ScoreUpdatedDate { get; set; }

    }
}
