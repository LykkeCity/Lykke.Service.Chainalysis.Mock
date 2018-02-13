// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Service.ChainalysisMock.Client.AutorestClient.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class UserImportModel
    {
        /// <summary>
        /// Initializes a new instance of the UserImportModel class.
        /// </summary>
        public UserImportModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the UserImportModel class.
        /// </summary>
        public UserImportModel(string userId = default(string), IList<string> depositAddresses = default(IList<string>), IList<string> withdrawalAddresses = default(IList<string>), IList<string> sentOutputs = default(IList<string>), IList<string> receivedOutputs = default(IList<string>))
        {
            UserId = userId;
            DepositAddresses = depositAddresses;
            WithdrawalAddresses = withdrawalAddresses;
            SentOutputs = sentOutputs;
            ReceivedOutputs = receivedOutputs;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "depositAddresses")]
        public IList<string> DepositAddresses { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "withdrawalAddresses")]
        public IList<string> WithdrawalAddresses { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sentOutputs")]
        public IList<string> SentOutputs { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "receivedOutputs")]
        public IList<string> ReceivedOutputs { get; set; }

    }
}
