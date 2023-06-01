using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsDealerApi.Dtos.Purchase
{
    public class GetPurchaseDto
    {   
        public decimal Amount { get; set; }
        public PaymentMethod Payment { get; set; }
    }
}