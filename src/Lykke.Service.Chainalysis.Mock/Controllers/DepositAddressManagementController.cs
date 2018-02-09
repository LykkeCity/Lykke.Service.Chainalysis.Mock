using System.Threading.Tasks;
using Lykke.Service.Chainalysis.Mock.Contracts;
using Lykke.Service.ChainalysisMock.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Lykke.Service.ChainalysisMock.Controllers
{
    [SwaggerOperationFilter(typeof(CustomResponseType))]
    public class DepositAddressManagementController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">The ID of the user</param>
        /// <param name="limit">The maximum number of items to return.</param>
        /// <param name="offset">The offset into the result set</param>
        /// <returns></returns>
        [HttpGet("/user/{userId}/addresses/deposit")]
        [SwaggerOperation(Tags = new[] { "Deposit Address Management" })]
        [SwaggerResponse(200, typeof(IUserDepositAddressInfo), "Successful response")]
        public async Task<ActionResult> GetAddressDeposits(string userId, int? limit, int? offset)
        {
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">The ID of the user</param>
        /// <param name="depositeAddress">The deposit address</param>
        /// <returns></returns>
        [HttpPost("/user/{userId}/addresses/deposit")]
        [SwaggerOperation(Tags = new[] { "Deposit Address Management" })]
        [SwaggerResponse(200, typeof(IAddressInfo), "Successful response")]
        [SwaggerResponse(409, typeof(string), "Conflict: The address is associated with another user. This could be another user in a different organization. If this occurs either this request, or the request that did the original registration is in error. If the deposit address was registered in another organization than yours please contact support@chainalysis.com")]
        public async Task<ActionResult> AddAddressDeposits(string userId, [FromBody] AddressImportModel depositeAddress)
        {
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">The ID of the user</param>
        /// <param name="address">The address to delete</param>
        /// <returns></returns>
        [HttpDelete("/user/{userId}/addresses/deposit/{address}")]
        [SwaggerOperation(Tags = new[] { "Deposit Address Management" })]
        [SwaggerResponse(200, typeof(object), "Successful response")]
        public async Task<ActionResult> DeleteAddressDeposit(string userId, string address)
        {
            return Ok();
        }
    }
}
