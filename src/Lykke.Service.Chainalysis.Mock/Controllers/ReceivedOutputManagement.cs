using System.Threading.Tasks;
using Lykke.Service.Chainalysis.Mock.Contracts;
using Lykke.Service.ChainalysisMock.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Lykke.Service.ChainalysisMock.Controllers
{
    [Route("api/receivedOutputManagement")]
    public class ReceivedOutputManagement : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// <p>List received outputs associated with a user.</p>
        ///<p>For each output the following is listed:</p>
        ///<ul>
        ///<li><p><code>output</code>: the actual output</p>
        ///</li>
        ///<li><p><code>status</code>: the status of the output.Can be:</p>
        ///<ul>
        ///<li><p><code>unconfirmed</code>: if the transaction has not yet confirmed</p>
        ///</li>
        ///<li><p><code>confirmed</code>: if the transaction has confirmed, but not yet settled</p>
        ///</li>
        ///<li><p><code>settled</code>: if the transaction has at least 5 confirmations.</p>
        ///</li>
        ///</ul>
        ///</li>
        ///</ul>
        ///<p><strong>Note:</strong> Only settlet outputs take part in risk score calculations</p>
        ///<p><strong>Note:</strong> Once an output has settled it cannot be deleted.</p>
        /// </remarks>
        /// <param name="userId">The ID of the user</param>
        /// <param name="status">The status of the output</param>
        /// <param name="limit">The maximum number of items to return.</param>
        /// <param name="offset">The offset into the result set</param>
        /// <returns></returns>
        [HttpGet("/user/{userId}/outputs/received")]
        [SwaggerOperation(Tags = new[] { "Received Output Management" })]
        [SwaggerResponse(200, typeof(IUserTransactionInfo), "Successful response")]

        public async Task<ActionResult> GetOutputReceives(string userId, TransactionStatus? status, int? limit, int? offset)
        {
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// <p>Add a received output associated with a user.</p>
        ///<p>Call this function to register that your service has received a transaction output on behalf of a user.</p>
        ///<p>A transaction output can be specified in two ways:</p>
        ///<ol>
        ///<li><strong>Transaction hash with output index.</strong> E.g.the second output of the transaction with the hash<code>77b8b931b3f7cd17e06dee680b77b28bb0809c88087343d657600730ca7ba15e</code> has index 1 and is specified like this <code>"77b8b931b3f7cd17e06dee680b77b28bb0809c88087343d657600730ca7ba15e:1"</code></li>
        ///<li><strong>Transaction hash with output address.</strong> E.g.the second output of the transaction with the hash<code>77b8b931b3f7cd17e06dee680b77b28bb0809c88087343d657600730ca7ba15e</code> has output address <code>19eAxqvy3F3i2yNMWNjzwcKbSnMn9kpG1Z</code> and is specified like this <code>"77b8b931b3f7cd17e06dee680b77b28bb0809c88087343d657600730ca7ba15e:19eAxqvy3F3i2yNMWNjzwcKbSnMn9kpG1Z"</code></li>
        ///</ol>
        ///<p>The first form is preferred because the second form is ambigious in cases where the transaction has more than one output to the specified address.</p>
        ///<p>The return value contains a risk <code>score</code>, e.g. <code>red</code>, <code>amber</code>, or<code> green</code>:</p>
        ///<ul>
        ///<li><p><code>red</code>: This output was received directly from a suspicious sender.</p>
        ///</li>
        ///<li><p><code>amber</code>: This output was received from an unidentified sender.</p>
        ///</li>
        ///<li><p><code>green</code>: This output was received from an identified non-suspicious sender. </p>
        ///</li>
        ///</ul>
        ///<p>If the transaction has one or more confirmations and if the counterparty is identified the return value will contain<code> name</code> and<code> category</code> of the counterparty.</p>
        ///<p><strong>Note</strong>: If the transaction has not yet confirmed<code> score</code> will be <code>amber</code>.Therefore it is advised to call this function twice, once your service observes the output, and once the transaction has confirmed, just before crediting the amount of the output to the user.</p>
        ///<p><strong>Note</strong>: The user is automatically created if it does not exist.</p>
        ///<p><strong>Note</strong>: The function is idempotent: If the sent output is already associated with the user the function succeeds.</p>
        ///<p><strong>Note:</strong> If an output is not settled within 7 days it is silently discarded.</p>
        /// </remarks>
        /// <param name="userId">The ID of the user</param>
        /// <param name="output">The transaction output</param>
        /// <returns></returns>
        [HttpPost("/user/{userId}/outputs/received")]
        [SwaggerOperation(Tags = new[] { "Received Output Management" })]
        [SwaggerResponse(200, typeof(IReceiveOutputInfo), "Successful response")]
        public async Task<ActionResult> AddOutputReceives(string userId, [FromBody] OutputImportModel output)
        {
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// <p>Delete a received outputs associated with a user.</p>
        /// <p><strong>Note:</strong> Once an output has settled it cannot be deleted.</p>
        /// </remarks>
        /// <param name="userId">The ID of the user</param>
        /// <param name="tx">The hash of the transaction output</param>
        /// <param name="output">The output index or output address</param>
        /// <returns></returns>
        [HttpDelete("/user/{userId}/outputs/received/{tx}/{output}")]
        [SwaggerOperation(Tags = new[] { "Received Output Management" })]
        [SwaggerResponse(200, typeof(object), "Successful response")]
        public async Task<ActionResult> DeleteOutputReceive(string userId, string tx, string output)
        {
            return Ok();
        }
    }

}
