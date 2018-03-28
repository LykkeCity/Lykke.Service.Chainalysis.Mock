namespace Lykke.Service.Chainalysis.Mock.Contracts
{
    public class UserDataModel
    {
        public string UserId { get; set; }
        public long LastActivity { get; set; }
        public string Score { get; set; }
        public long ScoreUpdatedDate { get; set; }
    }
}
