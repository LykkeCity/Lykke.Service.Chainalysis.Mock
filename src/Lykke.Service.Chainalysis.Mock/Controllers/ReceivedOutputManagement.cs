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
        [HttpGet("/user/{userId}/outputs/received")]
        [SwaggerOperation(Tags = new[] { "Received Output Management" })]
        [SwaggerResponse(200, typeof(IUserTransactionInfo), "Successful response")]
        
        public async Task<ActionResult> GetOutputReceives(string userId, TransactionStatus? status, int? limit, int? offset)
        {
            return Ok();
        }


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
