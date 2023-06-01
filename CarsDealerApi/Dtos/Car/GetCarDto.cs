using CarsDealerApi.Dtos.Purchase;

namespace Dtos.Car
{
    public class GetCarDto
    {
        public int Id { get; set;}
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int Mileage { get; set; }
        public GetPurchaseDto? Purchase { get; set; }
    }
}