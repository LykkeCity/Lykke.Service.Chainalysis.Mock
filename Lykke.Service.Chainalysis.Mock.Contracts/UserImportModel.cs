using System.Collections.Generic;

namespace Lykke.Service.Chainalysis.Mock.Contracts
{
    public class UserImportModel
    {
        public string UserId { get; set; }
        public List<string> DepositAddresses { get; set; }
        public List<string> WithdrawalAddresses { get; set; }
        public List<string> SentOutputs { get; set; }
        public List<string> ReceivedOutputs { get; set; }


    }
}
