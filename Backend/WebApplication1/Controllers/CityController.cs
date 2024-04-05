using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {

        private readonly ILogger<CityController> _logger;

        public CityController(ILogger<CityController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/GetCities")]
        public IActionResult GetCities()
        {
            //W-TODO: cross check lat lng and seed to db
            var cities = new List<City>
            {
                new City { Id = 1, Name = "Kuala Lumpur", Latitude = 3.139, Longitude = 101.6869 },
                new City { Id = 2, Name = "George Town", Latitude = 5.4141, Longitude = 100.3288 },
                new City { Id = 3, Name = "Ipoh", Latitude = 4.5975, Longitude = 101.0901 },
                new City { Id = 4, Name = "Kuching", Latitude = 1.5495, Longitude = 110.3593 },
                new City { Id = 5, Name = "Johor Bahru", Latitude = 1.4927, Longitude = 103.7414 },
                new City { Id = 6, Name = "Kota Kinabalu", Latitude = 5.9804, Longitude = 116.0735 },
                new City { Id = 7, Name = "Shah Alam", Latitude = 3.0738, Longitude = 101.5183 },
                new City { Id = 8, Name = "Malacca City", Latitude = 2.1896, Longitude = 102.2501 },
                new City { Id = 9, Name = "Alor Setar", Latitude = 6.1244, Longitude = 100.3674 },
                new City { Id = 10, Name = "Miri", Latitude = 4.3992, Longitude = 113.9916 }
            };
            return Ok(cities);
        }


    }
}
