namespace CarsDealerApi.Model
{
    public class Car 
    {
        public int Id { get; set;}
        public string Make { get; set; } =string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal Price { get; set; } 
        public int Mileage { get; set; }
        public List<TestDrive>? TestDrive { get; set; }
        public List<Offer>? Offers  {get; set;}
        public Purchase? Purchase { get; set; }
        public DealerAccount? Dealer { get; set; }
    }
}