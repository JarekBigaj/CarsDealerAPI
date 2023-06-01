namespace Dtos.Car
{
    public class AddCarDto
    {
        public string Make { get; set; } 
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int Mileage { get; set; }
    }
}