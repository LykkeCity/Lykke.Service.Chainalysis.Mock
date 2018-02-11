using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Lykke.Service.Chainalysis.Mock.Contracts;
using Lykke.Service.ChainalysisMock.Core.Domain;
using Microsoft.AspNetCore.Mvc;
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
        /// </summary>
        /// <remarks>
        ///<p>List users with optional filters.</p>
        ///<p>For each user the following is returned:</p>
        ///<ul>
        ///<li><p><code>userId</code>: the ID of the user</p>
        ///</li>
        ///<li><p><code>score</code>: the risk score of the user.E.g. <code>red</code>, <code>amber</code>, or<code> green</code>. Only included if the user has sent or received value.</p>
        ///</li>
        ///<li><p><code>scoreUpdatedDate</code>: the last time the risk score has been updated in POSIX format. Only included if the user has sent or received value.</p>
        ///</li>
        ///<li><p><code>lastActivity</code>: the last time the user sent or received value in POSIX format. Only included if the user has sent or received value.</p>
        ///</li>
        ///</ul>
        ///<p>Hint: to only return users with score<code> red</code> set the <code>score</code> parameter to<code> red</code></p>
        ///<p>Hint: To only return users that have sent or received value over the last 2 weeks set the<code> maxIdleDays</code> parameter to 14</p>
        /// </remarks>
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
        /// <remarks>
        ///<p>Import a user with sent and received history.</p>
        ///<p>With this function you can import a whole user with sent and received output history and all deposit and withdrawal addresses.</p>
        ///        <p>The import format is as follows:</p>
        ///<ul>
        ///<li><p><code>userId</code>: the unique ID of the user. The caller decides the user ID and can specify any value containing the folllowing characters '-' '_' 'a-z' 'A-Z' '0-9' with a maximum of 200 characters.</p>
        ///</li>
        ///<li><p><code>depositAddresses</code>: The deposit addresses of the user. Specified as an array of strings where each address must be a valid Bitcoin addresses.</p>
        ///</li>
        ///<li><p><code>withdrawalAddresses</code>: The withdrawal addresses of the user. Specified as an array of strings where each address must be a valid Bitcoin addresses.</p>
        ///</li>
        ///<li><p><code>sentOutputs</code>: The transaction outputs sent by the user.See below for a specification on how to format an output.</p>
        ///</li>
        ///<li><p><code>receivedOutputs</code>: The transaction outputs received by the user.See below for a specification on how to format an output.</p>
        ///</li>
        ///</ul>
        ///<p>Sent or received outputs can be specified in two ways:</p>
        ///<ul>
        ///<li><p>A transaction hash followed by the index of the output counting from zero: <code>tx-hash:output-index</code>.Exmaple: The first output of of the transaction<code> d03104f31dfbea2fa0e9c871790fbd1864d5b43354612c5b0b725eeb73bb7b8e</code> is specified like this <code>"d03104f31dfbea2fa0e9c871790fbd1864d5b43354612c5b0b725eeb73bb7b8e:0"</code> and the second output like this <code>"d03104f31dfbea2fa0e9c871790fbd1864d5b43354612c5b0b725eeb73bb7b8e:1"</code></p>
        ///</li>
        ///<li><p>A transaction hash followed by the address of the output: <code>tx-hash:output-address</code>.Exmaple: The first output of of the transaction<code> d03104f31dfbea2fa0e9c871790fbd1864d5b43354612c5b0b725eeb73bb7b8e</code> is specified like this <code>"d03104f31dfbea2fa0e9c871790fbd1864d5b43354612c5b0b725eeb73bb7b8e:1ERWgzFdPwbAYM6GWg9dUX1Q3KssatXgYz"</code> and the second output like this <code>"d03104f31dfbea2fa0e9c871790fbd1864d5b43354612c5b0b725eeb73bb7b8e:16F5EJE8mgiEDJzKqRdWUzdB54WceDRfjx"</code></p>
        ///</li>
        ///</ul>
        ///<p><strong>Note</strong>: The second output format can be ambigious in cases where the output address appears more than once in the outputs of a single transaction. If this occurs the first matching output is selected.</p>
        ///<p><strong>Note</strong>: Importing a user with sent or received outputs with less than 5 confirmations will fail.</p>
        ///<p><strong>Note</strong>: Subsequent import calls with the same userId are incremental, meaning that you can import another (E.g. new) version of a user on top of what is registered for that user already.In other words, any existing outputs or addresses which are not in the new import will NOT get deleted.</p>
        ///<p><strong>Note</strong>: If one of the deposit addresses are associated with a different user the function fails(see Response Messages below).</p>
        ///</remarks>
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
        /// <remarks>
        /// <p>Get information about a user.</p>
        ///<p>The follwing information is returned:</p>
        ///<ul>
        ///<li><p><code>userId</code>: the ID of the user</p>
        ///</li>
        ///<li><p><code>creationDate</code>: the POSIX time when the user was created</p>
        ///</li>
        ///<li><p><code>comment</code>: an arbitrary string that can be set using another API function.Only included if set.</p>
        ///</li>
        ///<li><p><code>score</code>: the risk score of the user. E.g. <code>red</code>, <code>amber</code>, or<code> green</code>. Only included if the user has sent or received value.</p>
        ///</li>
        /// <li><p><code>scoreUpdatedDate</code>: the last time the risk score has been updated in POSIX format. Only included if the user has sent or received value.</p>
        /// </li>
        /// <li><p><code>lastActivity</code>: the last time the user sent or received value in POSIX format. Only included if the user has sent or received value.</p>
        /// </li>
        /// <li><p><code>exposureDetails</code>: detailed exposure data.Only included if the user has sent or received value.</p>
        ///<ul>
        ///<li><p><code>category</code>: exposure category.</p>
        ///</li>
        ///<li><p><code>sentIndirectExposure</code>: funds sent indirectly.</p>
        ///</li>
        ///<li><p><code>sentDirectExposure</code>: funds sent directly.</p>
        ///</li>
        ///<li><p><code>receivedIndirectExposure</code>: funds received indirectly.</p>
        ///</li>
        ///<li><p><code>receivedDirectExposure</code>: funds received directly.</p>
        ///</li>
        ///</ul>
        ///</li>
        ///</ul>
        /// </remarks>
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
        /// <remarks>
        /// <p>Set the <code>comment</code> string on a user.</p>
        /// <p>This is a convenience function that allows you to set an arbitrary string for a user.When retrieving a user the string is returned.</p>
        /// </remarks>
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
