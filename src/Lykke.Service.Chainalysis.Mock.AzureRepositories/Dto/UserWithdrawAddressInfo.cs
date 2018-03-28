using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lykke.Service.ChainalysisMock.Core.Domain;

namespace Lykke.Service.ChainalysisMock.AzureRepositories.Dto
{
    public class UserWithdrawAddressInfo : IUserWithdrawAddressInfo
    {
        public UserWithdrawAddressInfo()
        {
            Limit = 0;
            Offset = 0;
        }

        public UserWithdrawAddressInfo(IEnumerable<IWithdrawAddressInfo> addresses)
        {
            Data = addresses.ToList();
            Total = Data.Count;
        }

        public long Total { get; set; }
        public long Limit { get; set; }
        public long Offset { get; set; }
        public List<IWithdrawAddressInfo> Data { get; set; }
    }
}
