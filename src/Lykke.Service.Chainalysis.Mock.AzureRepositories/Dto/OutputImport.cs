using System;
using System.Collections.Generic;
using System.Text;
using Lykke.Service.ChainalysisMock.Core.Domain;

namespace Lykke.Service.ChainalysisMock.AzureRepositories.Dto
{
    public class OutputImport : IOutputImport
    {
        public OutputImport(string output)
        {
            Output = output;
        }
        public string Output { get; set; }
    }
}
