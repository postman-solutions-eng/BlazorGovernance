using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PlainEnglishBlazor.DataAccess.Database;
using PlainEnglishBlazor.Shared.Models;
using RestSharp;

namespace PlainEnglishBlazor.Business
{
    public class WeatherForecastService
    {
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

        public async Task<List<WeatherForecast>> GetForecastsAsync(bool mock)
        {
            if (mock)
            {
                var options = new RestClientOptions("https://f319cfe2-4360-4c10-96e7-ee5959af154a.mock.pstmn.io")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/api/Weather/get", Method.Get);
                RestResponse response = await client.ExecuteAsync(request);
                
                return JsonConvert.DeserializeObject<List<WeatherForecast>>(response.Content!)!;
            }

            using (var context = new ApiContext())
            {
                var weather = await context.Weather.ToListAsync();
                return weather;
            }

        }
    }
}