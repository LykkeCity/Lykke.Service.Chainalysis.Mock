using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Service.ChainalysisMock.Core.Domain
{
    public interface IUserImport
    {
        string UserId { get; set; }
        List<string> DepositAddresses { get; set; }
        List<string> WithdrawalAddresses { get; set; }
        List<string> SentOutputs { get; set; }
        List<string> ReceivedOutputs { get; set; }
    }
}
