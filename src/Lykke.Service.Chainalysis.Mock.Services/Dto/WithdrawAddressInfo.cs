using System;
using System.Collections.Generic;
using System.Text;
using Lykke.Service.ChainalysisMock.Core.Domain;

namespace Lykke.Service.ChainalysisMock.Services.Dto
{
    public class WithdrawAddressInfo : IWithdrawAddressInfo
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Score { get; set; }
    }
}
