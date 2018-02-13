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

        public int Total { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public List<IWithdrawAddressInfo> Data { get; set; }
    }
}
