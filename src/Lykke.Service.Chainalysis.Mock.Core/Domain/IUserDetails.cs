using System.Collections.Generic;

namespace Lykke.Service.ChainalysisMock.Core.Domain
{
    public interface IUserDetails
    {
        string UserId { get; set; }
        long CreationDate { get; set; }
        string Comment { get; set; }
        long LastActivity { get; set; }
        string Score { get; set; }
        long ScoreUpdatedDate { get; set; }
        List<IUserExplosureDetails> ExposureDetails { get; set; }

    }
}
