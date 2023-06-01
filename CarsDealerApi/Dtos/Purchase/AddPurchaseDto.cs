using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsDealerApi.Dtos.Purchase
{
    public class AddPurchaseDto
    {
        public decimal Amount { get; set; }
        public PaymentMethod Payment { get; set; }
        public int CarId { get; set; }
    }
}