namespace WebApplication1.Models
{
    public class City
    {
        public int Id { get; set; }
        //W-TODO: make name required
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
