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
    [Route("api/withdrawalAddressManagement")]
    public class WithdrawalAddressManagementController : BaseController
    {

        private readonly IChainalysisMockService _chainalysisMockService;

        public WithdrawalAddressManagementController(IChainalysisMockService chainalysisMockService)
        {
            _chainalysisMockService = chainalysisMockService;
        }


        /// <summary>
        /// </summary>
        /// <remarks>
        ///<p>List withdrawal addresses associated with a user.</p>
        ///<ul>
        ///<li><p>Each withdrawal address is given a risk<code> score</code>. E.g. <code>red</code>, <code>amber</code>, or<code> green</code>.</p>
        ///</li>
        ///<li><p>If a withdrawal address belongs to a known service, then<code> name</code> and<code> category</code> will be included and gives the name and category of that service. Otherwise<code> name</code> and<code> category</code> will be omitted.</p>
        ///</li>
        ///</ul>
        /// </remarks>
        /// <param name="userId">The ID of the user</param>
        /// <param name="limit">The maximum number of items to return.</param>
        /// <param name="offset">The offset into the result set</param>
        /// <returns></returns>
        [HttpGet("/user/{userId}/addresses/withdrawal")]
        [SwaggerOperation(Tags = new[] { "Withdrawal Address Management" })]
        [SwaggerResponse(200, typeof(IUserWindrowAddressInfo), "Successful response")]
        public async Task<ActionResult> GetAddressWithdrawal(string userId, int? limit, int? offset)
        {
            return Ok(await _chainalysisMockService.GetUserWithdrawAsync(Token, userId, limit, offset));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// <p>Add a withdrawal address associated with a user.</p>
        ///<ul>
        ///<li><p>The user is automatically created if it does not exist.</p>
        ///</li>
        ///<li><p>The function is idempotent: If the withdrawal address is already associated with the user the function succeeds.</p>
        ///</li>
        ///</ul>
        ///<p>The function returns an analysis of the withdrawal address:</p>
        ///<ul>
        ///<li><p>A risk <code>score</code>.E.g. <code>red</code>, <code>amber</code>, or<code> green</code>.</p>
        ///</li>
        ///<li><p>If a withdrawal address belongs to a known service, then<code> name</code> and<code> category</code> will be included and gives the name and category of that service. Otherwise<code> name</code> and<code> category</code> will be omitted.</p>
        ///</li>
        ///</ul>
        ///<p>Hint: This function could be called both when a user pastes in the withdrawal address for the first time, and also before each subsequent withdrawal.</p>
        /// </remarks>
        /// <param name="userId">The ID of the user</param>
        /// <param name="withdrawalAddress">The withdrawal address</param>
        /// <returns></returns>
        [HttpPost("/user/{userId}/addresses/withdrawal")]
        [SwaggerOperation(Tags = new[] { "Withdrawal Address Management" })]
        [SwaggerResponse(200, typeof(IWindrowAddressInfo), "Successful response")]
        public async Task<ActionResult> AddAddressWithdrawals(string userId, [FromBody] AddressImportModel withdrawalAddress)
        {
            return Ok(await _chainalysisMockService.AddAddressWithdrawAsync(Token, userId, Mapper.Map<AddressImport>(withdrawalAddress)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete a withdrawal address associated with a user.
        /// </remarks>
        /// <param name="userId">The ID of the user</param>
        /// <param name="address">The address to delete</param>
        /// <returns></returns>
        [HttpDelete("/user/{userId}/addresses/withdrawal/{address}")]
        [SwaggerOperation(Tags = new[] { "Withdrawal Address Management" })]
        [SwaggerResponse(200, typeof(object), "Successful response")]
        public async Task<ActionResult> DeleteAddressWithdrawal(string userId, string address)
        {
            return Ok(await _chainalysisMockService.DeleteWithdrawalAsync(Token, userId, address));
        }
    }

   
}
