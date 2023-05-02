using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [StringLength(300, MinimumLength = 30)]
        public string? Summary { get; set; }
    }
}