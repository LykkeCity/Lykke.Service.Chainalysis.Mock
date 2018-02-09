using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Service.ChainalysisMock.Core.Domain
{
    public interface IReceiveOutputInfo
    {
        string Score { get; set; }
        string Name { get; set; }
        string Category { get; set; }
    }
}
