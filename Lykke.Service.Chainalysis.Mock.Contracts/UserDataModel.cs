namespace Lykke.Service.Chainalysis.Mock.Contracts
{
    public class UserDataModel
    {
        public string UserId { get; set; }
        public int LastActivity { get; set; }
        public string Score { get; set; }
        public int ScoreUpdatedDate { get; set; }
    }
}
