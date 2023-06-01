using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsDealerApi.Model
{
    public class Purchase
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod Payment { get; set; }
        public User? User { get; set; }
        public Car? Car { get; set; }
    }
}