using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarsDealerApi.Dtos.Offer;
using CarsDealerApi.Model;
using Data;
using Microsoft.EntityFrameworkCore;
using Model;

namespace CarsDealerApi.Services.OfferService
{
    public class OfferService : IOfferService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public OfferService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
            
        }
        public Task<ServiceResponse<GetOfferDto>> AcceptedOffer(AccepteOfferDto accepteOffer)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetOfferDto>>> AddOffer(AddOfferDto newOffer)
        {
            var serviceResponse = new ServiceResponse<List<GetOfferDto>>();
            var offer = _mapper.Map<Offer>(newOffer);
            _context.Offers.Add(offer);
            await _context.SaveChangesAsync();

            serviceResponse.Data =
                await _context.Offers.Select(offer => _mapper.Map<GetOfferDto>(offer)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetOfferDto>>> GetAllOffer(int userId)
        {
            var serviceResponse = new ServiceResponse<List<GetOfferDto>>();
            var offers = await _context.Offers.Where(offer => offer.User!.Id == userId).ToListAsync();
            serviceResponse.Data = offers.Select(offer => _mapper.Map<GetOfferDto>(offer)).ToList();
            return serviceResponse;
        }

        public Task<ServiceResponse<GetOfferDto>> GetOfferById(int id)
        {
            throw new NotImplementedException();
        }
    }
}