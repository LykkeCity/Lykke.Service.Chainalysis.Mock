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

        public long Total { get; set; }
        public long Limit { get; set; }
        public long Offset { get; set; }
        public List<ITransactionInfo> Data { get; set; }
    }
}
