using System.Collections.Generic;

namespace Lykke.Service.Chainalysis.Mock.Contracts
{
    public class UserDepositAddressInfoModel
    {
        public long Total { get; set; }
        public long Limit { get; set; }
        public long Offset { get; set; }
        public List<AddressInfoModel> Data { get; set; }
    }
}
