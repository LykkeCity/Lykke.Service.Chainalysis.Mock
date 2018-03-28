using System.Collections.Generic;

namespace Lykke.Service.ChainalysisMock.Core.Domain
{
    public interface IPagedList<T>
    {
        long Total { get; set; }
        long Limit { get; set; }
        long Offset { get; set; }
        List<T> Data { get; set; }
    }
}
