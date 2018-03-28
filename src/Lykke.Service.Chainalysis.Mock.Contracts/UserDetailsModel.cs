using System.Collections.Generic;

namespace Lykke.Service.Chainalysis.Mock.Contracts
{
    public class UserDetailsModel
    {
        public string UserId { get; set; }
        public long CreationDate { get; set; }
        public string Comment { get; set; }
        public long LastActivity { get; set; }
        public string Score { get; set; }
        public long ScoreUpdatedDate { get; set; }
        public List<UserExplosureDetailsModel> ExposureDetails { get; set; }
    }
}
