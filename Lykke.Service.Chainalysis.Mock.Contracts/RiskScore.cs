using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.Service.Chainalysis.Mock.Contracts
{
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum RiskScore
    {
        
        /// <summary>
        /// red
        /// </summary>
        Red,
        /// <summary>
        /// amger
        /// </summary>
        Amber,
        /// <summary>
        /// grem
        /// </summary>
        Green
    }
}
