using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class CitySeeder
    {
        public static void SeedCities(CityContext context)
        {
            // If there are any cities in the database, do not seed
            if (context.Cities.Count() > 0)
            {
                return;
            }
            var cities = new List<City>()
            {
                new City { Name = "Kangar", Latitude = 6.4, Longitude = 100.18 },
                new City { Name = "Alor Setar", Latitude = 6.12, Longitude = 100.38 },
                new City { Name = "Kota Bharu", Latitude = 5.3, Longitude = 100.28 },
                new City { Name = "Kuala Terengganu", Latitude = 5.03, Longitude = 103.15 },
                new City { Name = "Kuantan", Latitude = 3.8, Longitude = 103.33 },
                new City { Name = "Ipoh", Latitude = 4.6, Longitude = 100.59 },
                new City { Name = "Shah Alam", Latitude = 3.08, Longitude = 101.68 },
                new City { Name = "Seremban", Latitude = 2.72, Longitude = 102.25 },
                new City { Name = "Malacca City", Latitude = 2.19, Longitude = 102.25 },
                new City { Name = "Johor Bahru", Latitude = 1.42, Longitude = 103.73 },
                new City { Name = "George Town", Latitude = 5.41, Longitude = 100.33 },
                new City { Name = "Kota Kinabalu", Latitude = 5.98, Longitude = 116.08 },
                new City { Name = "Kuching", Latitude = 1.56, Longitude = 110.37 },
                new City { Name = "Putrajaya", Latitude = 2.93, Longitude = 101.69 },
                new City { Name = "Kuala Lumpur", Latitude = 3.13, Longitude = 101.71 },
                new City { Name = "Victoria", Latitude = 5.3, Longitude = 115.17 },
            };

            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}
