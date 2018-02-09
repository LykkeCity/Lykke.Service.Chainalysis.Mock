using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.Service.Chainalysis.Mock.Contracts
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
