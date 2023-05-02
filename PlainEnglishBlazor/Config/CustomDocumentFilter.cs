using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using PlainEnglishBlazor.Shared.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PlainEnglishBlazor.Config
{
    public class CustomDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.AddExtension("x-postman-custom", new OpenApiObject
            {
                ["address"] = new OpenApiString("http://some.backend.url")
            });
        }
    }
}
