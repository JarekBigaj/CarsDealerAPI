using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsDealerApi.Dtos.Purchase;
using CarsDealerApi.Services.PurchaseService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarsDealerApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("controller")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;
        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }   

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCarDto>>> AddPurchase(AddPurchaseDto newPurchase)
        {
            return Ok(await _purchaseService.AddPurchase(newPurchase));
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetPurchaseDto>>> GetAll()
        {
            return Ok(await _purchaseService.GetAllPurchase());
        }
    }
}