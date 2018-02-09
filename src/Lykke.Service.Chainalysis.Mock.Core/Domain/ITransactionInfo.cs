using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Service.ChainalysisMock.Core.Domain
{
    public interface ITransactionInfo
    {
        string Output { get; set; }
        string Status { get; set; }
    }
}
