using System;
using System.Collections.Generic;
using System.Text;
using Lykke.Service.ChainalysisMock.Core.Domain;

namespace Lykke.Service.ChainalysisMock.AzureRepositories.Dto
{
    public class AddressImport : IAddressImport
    {
        public AddressImport(string address)
        {
            Address = address;
        }
        public string Address { get; set; }
    }
}
