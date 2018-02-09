using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Lykke.Service.ChainalysisMock
{
    public class CustomResponseType : IOperationFilter
    {

        public void Apply(Operation operation, OperationFilterContext context)
        {
            operation.Produces.Clear();

            operation.Produces.Add("application/json");

        }
    }
}
