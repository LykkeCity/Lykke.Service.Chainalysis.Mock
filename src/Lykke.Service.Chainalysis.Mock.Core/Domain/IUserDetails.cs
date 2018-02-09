using System.Collections.Generic;

namespace Lykke.Service.ChainalysisMock.Core.Domain
{
    public interface IUserDetails
    {
        string UserId { get; set; }
        int CreationDate { get; set; }
        string Comment { get; set; }
        int LastActivity { get; set; }
        string Score { get; set; }
        int ScoreUpdatedDate { get; set; }
        List<UserExplosureDetails> ExposureDetails { get; set; }

    }
}
