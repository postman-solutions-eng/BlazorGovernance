using Swashbuckle.AspNetCore.Filters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace PlainEnglishBlazor.Shared.Models
{
    public class WeatherForecast
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        /// <summary>
        /// The temperature of the forecast in ISO-whatever format
        /// </summary>
        [Required]
        public int TemperatureC { get; set; }

        /// <summary>
        /// Autocalculated farenheit temperature.
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// The summary of the weather (cold, hot)
        /// </summary>
        [StringLength(300, MinimumLength = 3)]
        public string? Summary { get; set; }
    }

    public class WeatherExamples : IExamplesProvider<List<WeatherForecast>>
    {
        public List<WeatherForecast> GetExamples()
        {
            return new List<WeatherForecast>
            {
                new WeatherForecast { Id = 1, Date = new DateTime(2023, 1, 1), TemperatureC=32, Summary = "Test" },
                new WeatherForecast { Id = 2, Date= new DateTime(2023, 1, 2), TemperatureC=34, Summary = "Test 2" }
            };
        }
    }
}