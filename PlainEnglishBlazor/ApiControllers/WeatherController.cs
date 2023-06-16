using Microsoft.AspNetCore.Mvc;
using PlainEnglishBlazor.Shared.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

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
        /// Get Weather Forecasts
        /// </summary>
        [Route("get")]
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<WeatherForecast>>> GetWeatherForecasts()
        {
            var forecasts = await _weather.GetForecastsAsync(false);

            return Ok(forecasts);
        }

        /// <summary>
        /// Create Weather Forecast
        /// </summary>
        /// <param name="forecast">The Weather Forecast object represents the daily forecast in the requested weather location.</param>
        [Route("create")]
        [HttpPost]
        public IActionResult CreateWeatherForecasts(WeatherForecast forecast)
        {
            return Ok(forecast);
        }
    }
}
