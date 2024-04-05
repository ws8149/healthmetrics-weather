using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        // Get weather forecast for a specific city using OpenWeatherMap API
        [HttpPost]
        public async Task<IActionResult> GetWeatherForecast([FromBody] LocationData location)
        {
            var apiKey = _configuration["open_weather_api_key"];
            var url = $"https://api.openweathermap.org/data/2.5/forecast?lat={location.Latitude}&lon={location.Longitude}&appid={apiKey}&units=metric";
            using (var client = new HttpClient())
            {
                //W-TODO: Log err from OpenWeatherMap
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Ok(content);
                }
                else
                {
                    return BadRequest("Failed to get weather forecast");
                }
            }
        }

        public class LocationData
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }


    }
}
