using System.Threading.Tasks;
using Lykke.Service.Chainalysis.Mock.Contracts;
using Lykke.Service.ChainalysisMock.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Lykke.Service.ChainalysisMock.Controllers
{
    [Route("api/withdrawalAddressManagement")]
    public class WithdrawalAddressManagementController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">The ID of the user</param>
        /// <param name="limit">The maximum number of items to return.</param>
        /// <param name="offset">The offset into the result set</param>
        /// <returns></returns>
        [HttpGet("/user/{userId}/addresses/withdrawal")]
        [SwaggerOperation(Tags = new[] { "Withdrawal Address Management" })]
        [SwaggerResponse(200, typeof(IUserWindrowAddressInfo), "Successful response")]
        public async Task<ActionResult> GetAddressWithdrawal(string userId, int? limit, int? offset)
        {
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">The ID of the user</param>
        /// <param name="withdrawalAddress">The withdrawal address</param>
        /// <returns></returns>
        [HttpPost("/user/{userId}/addresses/withdrawal")]
        [SwaggerOperation(Tags = new[] { "Withdrawal Address Management" })]
        [SwaggerResponse(200, typeof(IWindrowAddressInfo), "Successful response")]
        public async Task<ActionResult> AddAddressWithdrawals(string userId, [FromBody] AddressImportModel withdrawalAddress)
        {
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">The ID of the user</param>
        /// <param name="address">The address to delete</param>
        /// <returns></returns>
        [HttpDelete("/user/{userId}/addresses/withdrawal/{address}")]
        [SwaggerOperation(Tags = new[] { "Withdrawal Address Management" })]
        [SwaggerResponse(200, typeof(object), "Successful response")]
        public async Task<ActionResult> DeleteAddressWithdrawal(string userId, string address)
        {
            return Ok();
        }
    }

   
}
