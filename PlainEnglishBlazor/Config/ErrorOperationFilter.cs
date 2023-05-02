using Microsoft.OpenApi.Models;
using PlainEnglishBlazor.Shared.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PlainEnglishBlazor.Config
{
    public class ErrorOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Generic 500
            operation.Responses.Add("500", new OpenApiResponse { 
                Description="This is an example of an error response" 
            });

            // Generic 404
            operation.Responses.Add("404", new OpenApiResponse
            {
                Description = "Not Found"
            });

            // Generic 401
            operation.Responses.Add("401", new OpenApiResponse
            {
                Description = "Unauthorized"
            });

            // Generic 403
            operation.Responses.Add("403", new OpenApiResponse
            {
                Description = "Forbidden"
            });
        }
    }
}
