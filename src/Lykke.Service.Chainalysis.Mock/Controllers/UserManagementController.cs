using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Lykke.Service.Chainalysis.Mock.Contracts;
using Lykke.Service.ChainalysisMock.Core;
using Lykke.Service.ChainalysisMock.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Internal;
using Swashbuckle.AspNetCore.SwaggerGen;
using RiskScore = Lykke.Service.Chainalysis.Mock.Contracts.RiskScore;

namespace Lykke.Service.ChainalysisMock.Controllers
{
    /// <summary>
    /// UserManagementController
    /// </summary>
    [SwaggerOperationFilter(typeof(CustomResponseType))]
    public class UserManagementController : BaseController
    {

        /// <summary>
        /// List users with optional filters.
        ///For each user the following is returned:
        ///userId: the ID of the user
        ///score: the risk score of the user.E.g.red, amber, or green. Only included if the user has sent or received value.
        ///scoreUpdatedDate: the last time the risk score has been updated in POSIX format. Only included if the user has sent or received value.
        ///lastActivity: the last time the user sent or received value in POSIX format. Only included if the user has sent or received value.
        ///Hint: to only return users with score red set the score parameter to red
        ///Hint: To only return users that have sent or received value over the last 2 weeks set the maxIdleDays parameter to 14
        /// </summary>
        /// <param name="maxIdleDays">Optionally filter the users by specifying the maximum numbers of days without sent or received activity.</param>
        /// <param name="score">Optionally filter the users by specifying the risk score.</param>
        /// <param name="limit">The maximum number of items to return.</param>
        /// <param name="offset">The offset into the result set</param>
        /// <returns></returns>
        [HttpGet("user")]
        [SwaggerOperation(Tags = new[]{"User Management"})]
        [SwaggerResponse(200, typeof(IUserInfo), "Successful response")]
        public async Task<ActionResult> GetUsers(int? maxIdleDays, RiskScore? score, int? limit, int? offset)
        {
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userImport"></param>
        /// <returns></returns>
        [HttpPost("user/import")]
        [SwaggerOperation(Tags = new[] { "User Management" })]
        [SwaggerResponse(200, description: "Successful response")]
        [SwaggerResponse(409, typeof(string), "Conflict: The address is associated with another user. This could be another user in a different organization. If this occurs either this request, or the request that did the original registration is in error. If the deposit address was registered in another organization than yours please contact support@chainalysis.com")]
        public async Task<ActionResult> ImportUser([FromBody] UserImportModel userImport)
        {
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">The ID of the user</param>
        /// <returns></returns>
        [HttpGet("user/{userId}")]
        [SwaggerOperation(Tags = new[] { "User Management" })]
        [SwaggerResponse(200,typeof(IUserDetails), "Successful response")]
        public async Task<ActionResult> GetUser(string userId)
        {
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">The ID of the user</param>
        /// <param name="comment">The deposit address</param>
        /// <returns></returns>
        [HttpPost("user/{userId}/comment")]
        [SwaggerOperation(Tags = new[] { "User Management" })]
        [SwaggerResponse(200, typeof(object), "Successful response")]
        public async Task<ActionResult> UpdateUserComments(string userId, [FromBody] CommentModel comment)
        {
            return Ok();
        }

    }
}
