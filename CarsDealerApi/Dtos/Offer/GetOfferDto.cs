using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsDealerApi.Model;

namespace CarsDealerApi.Dtos.Offer
{
    public class GetOfferDto
    {
        public int Id { get; set; }
        public decimal ProposedAmount { get; set; } 
        public bool IsAcepted { get; set; }
    }
}