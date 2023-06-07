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

    [ApiController]
    [Route("api/offer/[controller]")]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;
        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;   
        }
        [Authorize(Roles = "User")]
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetOfferDto>>>> Get() 
        {
            return Ok(await _offerService.GetAllOffer());
        }

        [Authorize(Roles = "User")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetOfferDto>>> GetSingle(int id) 
        {
            return Ok(await _offerService.GetOfferById(id));
        }

        [Authorize(Roles = "User")]
        [HttpPost("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetOfferDto>>>> AddOffer(AddOfferDto newOffer,int id)
        {
            return Ok(await _offerService.AddOffer(newOffer,id));
        }
        [Authorize(Roles = "CarsDealer")]
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetOfferDto>>>> AcceptOffer(AccepteOfferDto acceptedOffer)
        {
            var response = await _offerService.AcceptedOffer(acceptedOffer);
            if(response.Data is null)
                return NotFound(response);
            return Ok(response);
        }
        [Authorize(Roles = "User")]
        [HttpGet("GetAllCarsOffer")]
        public async Task<ActionResult<ServiceResponse<List<GetOfferDto>>>> GetAllCarsOffer() 
        {
            return Ok(await _offerService.GetAllOfferForEveryCar());
        }
    }
}