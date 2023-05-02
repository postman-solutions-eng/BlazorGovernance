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
        /// Gets List of Weather Forecasts
        /// </summary>
        [Route("get")]
        [HttpGet]
        [ProducesResponseType(typeof(WeatherForecast), 200)]
        public async Task<ActionResult<List<WeatherForecast>>> Get()
        {
            var forecasts = await _weather.GetForecastsAsync();

            return Ok(forecasts);
        }

        /// <summary>
        /// Create Weather Forecasts
        /// </summary>
        /// <param name="forecast">The Weather Forecast object represents the daily forecast in the requested weather location.</param>
        /// <returns>Returns string response</returns>
        [Route("create")]
        [HttpPost]
        public IActionResult Create(WeatherForecast forecast)
        {
            return Ok(forecast);
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
