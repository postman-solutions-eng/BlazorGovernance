using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using PlainEnglishBlazor.Business;
using PlainEnglishBlazor.Shared.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// DI Container
services.AddRazorPages();
services.AddServerSideBlazor();
services.AddScoped<WeatherForecastService>();
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { 
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

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    var modelAssembly = typeof(Error).Assembly;
    var modelsXmlDocPath = Path.Combine(AppContext.BaseDirectory, $"{modelAssembly.GetName().Name}.xml");
    options.IncludeXmlComments(modelsXmlDocPath);
});

// Application Builder
var app = builder.Build();
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
