using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsDealerApi.Dtos.Offer
{
    public class AccepteOfferDto
    {
        public int Id { get; set; }
        public bool IsAcepted { get; set; }
    }
}