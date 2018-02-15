using System.Collections.Generic;

namespace Lykke.Service.Chainalysis.Mock.Contracts
{
    public class UserDetailsModel
    {
        public string UserId { get; set; }
        public int CreationDate { get; set; }
        public string Comment { get; set; }
        public int LastActivity { get; set; }
        public string Score { get; set; }
        public int ScoreUpdatedDate { get; set; }
        public List<UserExplosureDetailsModel> ExposureDetails { get; set; }
    }
}
