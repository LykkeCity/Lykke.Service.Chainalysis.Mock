using System.Threading.Tasks;
using AutoMapper;
using Lykke.Service.Chainalysis.Mock.Contracts;
using Lykke.Service.ChainalysisMock.Core.Domain;
using Lykke.Service.ChainalysisMock.Core.Services;
using Lykke.Service.ChainalysisMock.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Lykke.Service.ChainalysisMock.Controllers
{
    [SwaggerOperationFilter(typeof(CustomResponseType))]
    public class DepositAddressManagementController : BaseController
    {

        private readonly IChainalysisMockService _chainalysisMockService;

        public DepositAddressManagementController(IChainalysisMockService chainalysisMockService)
        {
            _chainalysisMockService = chainalysisMockService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// List deposit addresses associated with a user.
        /// </remarks>
        /// <param name="userId">The ID of the user</param>
        /// <param name="limit">The maximum number of items to return.</param>
        /// <param name="offset">The offset into the result set</param>
        /// <returns></returns>
        [HttpGet("/user/{userId}/addresses/deposit")]
        [SwaggerOperation(Tags = new[] { "Deposit Address Management" })]
        [SwaggerResponse(200, typeof(IUserDepositAddressInfo), "Successful response")]
        public async Task<ActionResult> GetAddressDeposits(string userId, int? limit, int? offset)
        {
            return Ok(await _chainalysisMockService.GetUserDepositsAsync(Token, userId, limit, offset));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// <p>Add a deposit address associated with a user.</p>
        ///<p><strong>Note</strong>: The user is automatically created if it does not exist.</p>
        ///<p><strong>Note</strong>: The function is idempotent: If the deposit address is already associated with the user the function succeeds.</p>
        ///<p><strong>Note</strong>: If the deposit address is associated with a different user the function fails (see Response Messages below).</p>
        /// </remarks>
        /// <param name="userId">The ID of the user</param>
        /// <param name="depositeAddress">The deposit address</param>
        /// <returns></returns>
        [HttpPost("/user/{userId}/addresses/deposit")]
        [SwaggerOperation(Tags = new[] { "Deposit Address Management" })]
        [SwaggerResponse(200, typeof(IAddressInfo), "Successful response")]
        [SwaggerResponse(409, typeof(string), "Conflict: The address is associated with another user. This could be another user in a different organization. If this occurs either this request, or the request that did the original registration is in error. If the deposit address was registered in another organization than yours please contact support@chainalysis.com")]
        public async Task<ActionResult> AddAddressDeposits(string userId, [FromBody] AddressImportModel depositeAddress)
        {
            return Ok(await _chainalysisMockService.AddAddressDepositsAsync(Token, userId, Mapper.Map<AddressImport>(depositeAddress)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete a deposit address associated with a user.
        /// </remarks>
        /// <param name="userId">The ID of the user</param>
        /// <param name="address">The address to delete</param>
        /// <returns></returns>
        [HttpDelete("/user/{userId}/addresses/deposit/{address}")]
        [SwaggerOperation(Tags = new[] { "Deposit Address Management" })]
        [SwaggerResponse(200, typeof(object), "Successful response")]
        public async Task<ActionResult> DeleteAddressDeposit(string userId, string address)
        {
            return Ok(await _chainalysisMockService.DeleteDepositAddressAsync(Token, userId, address));
        }
    }
}
