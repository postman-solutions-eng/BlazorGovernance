using Microsoft.OpenApi.Models;
using PlainEnglishBlazor.Business;
using PlainEnglishBlazor.Config;
using PlainEnglishBlazor.Shared.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// DI Container
services.AddRazorPages();
services.AddServerSideBlazor();
services.AddScoped<WeatherForecastService>();
services.AddControllers();
services.AddEndpointsApiExplorer();

// Swagger Gen
services.AddSwaggerGen(options =>
{
    options.ExampleFilters();

    options.AddServer(new OpenApiServer()
    {
        Url = "https://localhost:61148"
    });

    options.SwaggerDoc("v1", new OpenApiInfo {
        Description = "This is a description for my API that will help improve discoverability.",
        Title = "Postman Example API", 
        Version = "v1", 
        Contact = new OpenApiContact
        {
            Name = "Garrett London",
            Email= "garrett.london@postman.com",
            Url = new Uri("https://example.com/contact")
        },
    });

    options.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Name = "Bearer",
                In = ParameterLocation.Header,
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    var modelAssembly = typeof(Error).Assembly;
    var modelsXmlDocPath = Path.Combine(AppContext.BaseDirectory, $"{modelAssembly.GetName().Name}.xml");
    options.IncludeXmlComments(modelsXmlDocPath);

    options.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["action"]}");
    options.OperationFilter<ErrorOperationFilter>();
    options.DocumentFilter<CustomDocumentFilter>();
});

services.AddSwaggerExamplesFromAssemblyOf(typeof(WeatherExamples));

// Application Builder
var app = builder.Build();

// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapControllers();
app.MapFallbackToPage("/_Host");
app.Run();
