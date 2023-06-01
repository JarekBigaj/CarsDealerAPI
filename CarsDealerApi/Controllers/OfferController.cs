using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsDealerApi.Dtos.Offer;
using CarsDealerApi.Services.OfferService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Security.Claims;

namespace CarsDealerApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/offer/[controller]")]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;
        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;   
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetOfferDto>>>> Get() 
        {
            int userId = int.Parse(User.Claims
                .FirstOrDefault(claims => claims.Type == ClaimTypes.NameIdentifier)!.Value);
            return Ok(await _offerService.GetAllOffer(userId));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetOfferDto>>>> AddOffer(AddOfferDto newOffer)
        {
            return Ok(await _offerService.AddOffer(newOffer));
        }
    }
}