using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.Service.ChainalysisMock.Core.Domain
{
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum TransactionStatus
    {
        Unconfirmed,
        Confirmed,
        Settled,
        Any
    }
}
