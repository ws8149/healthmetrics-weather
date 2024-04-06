using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class CityContext : DbContext
    {
        public IConfiguration _config { get; set; }
        public DbSet<City> Cities { get; set; }

        public CityContext(IConfiguration config)
        {
            _config = config;
            CitySeeder.SeedCities(this);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
        }
    }
}
