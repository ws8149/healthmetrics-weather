using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IDistributedCache _cache;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration, IDistributedCache cache)
        {
            _logger = logger;
            _configuration = configuration;
            _cache = cache;
        }

        // Get weather forecast for a specific city using OpenWeatherMap API
        [HttpPost("forecast")]
        public async Task<IActionResult> WeatherForecast([FromBody] CityDTO cityDto)
        {
            try
            {
                // Check if citydto id exists in redis cache
                var cachedData = _cache.GetString(cityDto.Id.ToString());

                if (cachedData != null)
                {
                    return Ok(cachedData);
                }
                else
                {
                    var apiKey = _configuration["OpenWeatherApiKey"];

                    var url = $"https://api.openweathermap.org/data/2.5/forecast?lat={cityDto.Latitude}&lon={cityDto.Longitude}&appid={apiKey}&units=metric";
                    using (var client = new HttpClient())
                    {
                        //W-TODO: Log err from OpenWeatherMap
                        var response = await client.GetAsync(url);
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();

                            // Calculate time until midnight
                            DateTime now = DateTime.Now;
                            DateTime midnight = now.Date.AddDays(1);
                            TimeSpan timeUntilMidnight = midnight - now;

                            // Cache data until midnight
                            await _cache.SetStringAsync(cityDto.Id.ToString(), content, new DistributedCacheEntryOptions
                            {
                                AbsoluteExpirationRelativeToNow = timeUntilMidnight
                            });
                            return Ok(content);
                        }
                        else
                        {
                            return BadRequest("Failed to get weather forecast");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get weather forecast");
                return BadRequest("Failed to get weather forecast");
            }
        }

    }
}
