using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsDealerApi.Dtos.Car;
using CarsDealerApi.Dtos.Offer;
using CarsDealerApi.Model;

namespace CarsDealerApi.Services.OfferService
{
    public interface IOfferService
    {
        Task<ServiceResponse<List<GetOfferDto>>> GetAllOffer();
        Task<ServiceResponse<GetOfferDto>> GetOfferById(int id);
        Task<ServiceResponse<List<GetOfferDto>>> AddOffer(AddOfferDto newOffer,int id);
        Task<ServiceResponse<GetOfferDto>> AcceptedOffer(AccepteOfferDto acceptedOffer);
        Task<ServiceResponse<List<GetCarOfferDto>>> GetAllOfferForEveryCar();
        
    }
}