using System;
using System.Collections.Generic;
using System.Text;
using Lykke.Service.ChainalysisMock.Core.Domain;

namespace Lykke.Service.ChainalysisMock.AzureRepositories.Dto
{
    public class AddressInfo : IAddressInfo
    {
        public AddressInfo()
        {
            
        }

        public AddressInfo(string address)
        {
            Address = address;
        }

        public string Address { get; set; }
    }
}
