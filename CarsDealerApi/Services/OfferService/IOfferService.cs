using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsDealerApi.Dtos.Offer;
using Model;

namespace CarsDealerApi.Services.OfferService
{
    public interface IOfferService
    {
        Task<ServiceResponse<List<GetOfferDto>>> GetAllOffer(int userId);
        Task<ServiceResponse<GetOfferDto>> GetOfferById(int id);
        Task<ServiceResponse<List<GetOfferDto>>> AddOffer(AddOfferDto newOffer);
        Task<ServiceResponse<GetOfferDto>> AcceptedOffer(AccepteOfferDto accepteOffer);
    }
}