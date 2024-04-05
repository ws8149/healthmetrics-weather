using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {

        private readonly ILogger<CityController> _logger;
        private readonly CityContext _context;

        public CityController(ILogger<CityController> logger, CityContext context)
        {
            _logger = logger;
            _context = context;   
        }

        [HttpGet("/GetCities")]
        public IActionResult GetCities()
        {
            List<City> cities = _context.Cities.ToList();
            return Ok(cities);
        }


    }
}
