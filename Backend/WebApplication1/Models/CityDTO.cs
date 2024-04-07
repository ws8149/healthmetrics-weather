namespace WebApplication1.Models
{
    public class CityDTO
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required double Latitude { get; set; }
        public required double Longitude { get; set; }
    }
}
