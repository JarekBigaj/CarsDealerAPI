using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsDealerApi.Dtos.Offer;

namespace CarsDealerApi.Dtos.Car
{
    public class GetCarOfferDto
    {
        public int Id { get; set;}
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<GetOfferDto>?  Offers { get; set; }
    }
}