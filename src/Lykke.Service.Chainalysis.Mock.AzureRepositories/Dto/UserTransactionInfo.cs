using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lykke.Service.ChainalysisMock.Core.Domain;

namespace Lykke.Service.ChainalysisMock.AzureRepositories.Dto
{
    public class UserTransactionInfo : IUserTransactionInfo
    {
        public UserTransactionInfo()
        {
            Limit = 0;
            Offset = 0;
        }

        public UserTransactionInfo(IEnumerable<ITransactionInfo> transactions)
        {
            Data = transactions.ToList();
            Total = Data.Count;
        }

        public int Total { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public List<ITransactionInfo> Data { get; set; }
    }
}
