using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lykke.Service.ChainalysisMock.Core.Domain;

namespace Lykke.Service.ChainalysisMock.AzureRepositories.Dto
{
    public class UserDepositAddressInfo : IUserDepositAddressInfo
    {
        public UserDepositAddressInfo()
        {
            Limit = 0;
            Offset = 0;
        }

        public UserDepositAddressInfo(IEnumerable<string> addresses)
        {
            Data = (from address in addresses
                    select (IAddressInfo)new AddressInfo(address)).ToList();
            Total = Data.Count;
        }

        public int Total { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public List<IAddressInfo> Data { get; set; }
    }
}
