// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Service.ChainalysisMock.Client.AutorestClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class IAddressInfo
    {
        /// <summary>
        /// Initializes a new instance of the IAddressInfo class.
        /// </summary>
        public IAddressInfo()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the IAddressInfo class.
        /// </summary>
        public IAddressInfo(string address = default(string))
        {
            Address = address;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

    }
}
