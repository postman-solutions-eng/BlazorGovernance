using Microsoft.AspNetCore.Mvc;
using PlainEnglishBlazor.Shared.Models;

namespace PlainEnglishBlazor.Business.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        readonly WeatherForecastService _weather;
        public WeatherController(WeatherForecastService weather)
        {
            _weather = weather;
        }

        /// <summary>
        /// Gets List of Weather Forecastss
        /// </summary>
        [Route("get")]
        [HttpGet]
        public async Task<ActionResult<List<WeatherForecast>>> Get()
        {
            var forecasts = await _weather.GetForecastsAsync();

            return Ok(forecasts);
        }
        /// <summary>
        /// Gets List of Weather Forecastss
        /// </summary>
        [Route("getwithoutsummary")]
        [HttpGet]
        public async Task<ActionResult<List<WeatherForecast>>> GetWithoutSummary()
        {
            var forecasts = await _weather.GetForecastsAsync();

            return Ok(forecasts);
        }
    }
}
