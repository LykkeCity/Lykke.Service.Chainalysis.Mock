using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.Service.ChainalysisMock.Core.Domain
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
