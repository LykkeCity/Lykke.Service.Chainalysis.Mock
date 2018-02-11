using System.Collections.Generic;
using System.Linq;
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

            operation.Consumes.Clear();
            operation.Consumes.Add("application/json");

            if (operation.Parameters == null || !operation.Parameters.Any())
            {
                return;
            }

            SetBodyParametersAsRequired(operation);

        }

        private void SetBodyParametersAsRequired(Operation operation)
        {
            IEnumerable<IParameter> bodyParameters = operation.Parameters.Where(p => p.In == "body");

            foreach (IParameter bodyParameter in bodyParameters)
            {
                bodyParameter.Required = true;
            }
        }
    }
}

