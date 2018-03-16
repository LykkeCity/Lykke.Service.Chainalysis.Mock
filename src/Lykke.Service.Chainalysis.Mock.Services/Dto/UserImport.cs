using System;
using System.Collections.Generic;
using System.Text;
using Lykke.Service.ChainalysisMock.Core.Domain;

namespace Lykke.Service.ChainalysisMock.Services.Dto
{
    public class UserImport : IUserImport
    {
        public string UserId { get; set; }
        public List<string> DepositAddresses { get; set; }
        public List<string> WithdrawalAddresses { get; set; }
        public List<string> SentOutputs { get; set; }
        public List<string> ReceivedOutputs { get; set; }
    }
}
