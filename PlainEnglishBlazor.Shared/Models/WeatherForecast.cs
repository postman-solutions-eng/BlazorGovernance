using Swashbuckle.AspNetCore.Filters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PlainEnglishBlazor.Shared.Models
{
    public class WeatherForecast
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <example>2023-01-01T00:00:00</example>
        public DateTime Date { get; set; }

        /// <summary>The temperature of the forecast in ISO-whatever format</summary>
        /// <example>32</example>
        [Required]
        public int TemperatureC { get; set; }

        /// <summary>Autocalculated farenheit temperature.</summary>
        /// <example>32</example>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary> The summary of the weather (cold, hot) </summary>
        /// <example>This is the summary for the weather</example>
        [StringLength(300, MinimumLength = 3)]
        public string? Summary { get; set; }

        /// <summary>The URL for the weather. Must be valid.</summary>
        /// <example>https://www.bing.com</example>
        public string? Website { get; set; }
    }

    public class WeatherExamples : IExamplesProvider<List<WeatherForecast>>
    {
        public List<WeatherForecast> GetExamples()
        {
            return new List<WeatherForecast>
            {
                new WeatherForecast { 
                    Id = 1, 
                    Date = new DateTime(2023, 1, 1), 
                    TemperatureC=32, 
                    Summary = "Test 1",
                    Website = "https://www.dotnet.microsoft.com"
                },
                new WeatherForecast { 
                    Id = 2, 
                    Date= new DateTime(2023, 1, 2), 
                    TemperatureC=34, 
                    Summary = "Test 2",
                    Website = "https://www.dotnet.microsoft.com"
                }
            };
        }
    }
}