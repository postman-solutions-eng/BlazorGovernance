using Microsoft.EntityFrameworkCore;
using PlainEnglishBlazor.DataAccess.Database;
using PlainEnglishBlazor.Shared.Models;

namespace PlainEnglishBlazor.Business
{
    public class WeatherForecastService
    {
        // Used by users logging into our app
        public async Task<WeatherForecast> PostForecastAsync(DateTime startDate)
        {
            var forecast = new WeatherForecast()
            {
                Date = startDate,
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = "The temperature of Day " + startDate.ToShortDateString()
            };

            using (var context = new ApiContext())
            {
                context.Weather.Add(forecast);
                await context.SaveChangesAsync();
            }

            return forecast;
        }

        // Used by Client Credential Tokens from Controller
        public async Task<List<WeatherForecast>> GetForecastsAsync()
        {
            using (var context = new ApiContext())
            {
                var weather = await context.Weather.ToListAsync();
                return weather;
            }
        }
    }
}