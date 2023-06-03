using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CarsDealerApi.Dtos.Offer;
using CarsDealerApi.Model;
using Data;
using Microsoft.EntityFrameworkCore;


namespace CarsDealerApi.Services.OfferService
{
    public class OfferService : IOfferService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OfferService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _mapper = mapper;
            
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.NameIdentifier)!);
        public async Task<ServiceResponse<GetOfferDto>> AcceptedOffer(AccepteOfferDto acceptedOffer)
        {
            var serviceResponse = new ServiceResponse<GetOfferDto>();
            try
            {
                var offer =  await _context.Offers.FirstOrDefaultAsync(offer => offer.Id == acceptedOffer.Id);
                if(offer is null)
                    throw new Exception($"Offer with Id '{acceptedOffer.Id}' not found.");

                offer.IsAcepted = acceptedOffer.IsAcepted;

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetOfferDto>(offer);
            } 
            catch(Exception exception)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = exception.Message;
            }


            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetOfferDto>>> AddOffer(AddOfferDto newOffer,int id)
        {
            var serviceResponse = new ServiceResponse<List<GetOfferDto>>();
            var offer = _mapper.Map<Offer>(newOffer);
            offer.User = await _context.Users.FirstOrDefaultAsync(user => user.Id == GetUserId());
            offer.Car = await _context.Cars.FirstOrDefaultAsync(car => car.Id == id);
            _context.Offers.Add(offer);
            await _context.SaveChangesAsync();

            serviceResponse.Data =
                await _context.Offers
                    .Where(offer => offer.User!.Id == GetUserId())
                    .Select(offer => _mapper.Map<GetOfferDto>(offer))
                    .ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetOfferDto>>> GetAllOffer()
        {
            var serviceResponse = new ServiceResponse<List<GetOfferDto>>();
            var offers = await _context.Offers.Where(offer => offer.User!.Id == GetUserId()).ToListAsync();
            
            serviceResponse.Data = offers.Select(offer => _mapper.Map<GetOfferDto>(offer)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetOfferDto>> GetOfferById(int id)
        {
            var serviceResponse = new ServiceResponse<GetOfferDto>();
            var offer = await _context.Offers
                .FirstOrDefaultAsync(offer => offer.Id == id && offer.User!.Id == GetUserId());
            serviceResponse.Data = _mapper.Map<GetOfferDto>(offer);
            return serviceResponse;
        }
    }
}