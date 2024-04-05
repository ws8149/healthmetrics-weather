using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class CityContext : DbContext
    {
        public DbSet<City> Cities { get; set; }

        public CityContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
