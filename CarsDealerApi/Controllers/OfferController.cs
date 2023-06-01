using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsDealerApi.Dtos.Offer;
using CarsDealerApi.Services.OfferService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


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
            return Ok(await _offerService.GetAllOffer());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetOfferDto>>> GetSingle(int id) 
        {
            return Ok(await _offerService.GetOfferById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetOfferDto>>>> AddOffer(AddOfferDto newOffer)
        {
            return Ok(await _offerService.AddOffer(newOffer));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetOfferDto>>>> AcceptOffer(AccepteOfferDto acceptedOffer)
        {
            var response = await _offerService.AcceptedOffer(acceptedOffer);
            if(response.Data is null)
                return NotFound(response);
            return Ok(response);
        }
    }
}