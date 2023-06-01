using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsDealerApi.Dtos.Purchase;
using CarsDealerApi.Model;

namespace CarsDealerApi.Services.PurchaseService
{
    public interface IPurchaseService
    {  
        Task<ServiceResponse<GetCarDto>> AddPurchase(AddPurchaseDto newPurchase);
        Task<ServiceResponse<List<GetPurchaseDto>>> GetAllPurchase();
    }
}