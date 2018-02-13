using System;
using System.Collections.Generic;
using System.Text;
using Lykke.Service.ChainalysisMock.Core.Domain;

namespace Lykke.Service.ChainalysisMock.AzureRepositories.Dto
{
    public class TransactionInfo : ITransactionInfo
    {
        public TransactionInfo()
        {
            
        }

        public TransactionInfo(string output, string status)
        {
            Output = output;
            Status = status;
        }

        public string Output { get; set; }
        public string Status { get; set; }
    }
}
