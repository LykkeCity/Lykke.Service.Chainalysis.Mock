using System.Collections.Generic;

namespace Lykke.Service.ChainalysisMock.Core.Domain
{
    public interface IPagedList<T>
    {
        int Total { get; set; }
        int Limit { get; set; }
        int Offset { get; set; }
        List<T> Data { get; set; }
    }
}
