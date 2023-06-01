using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CarsDealerApi.Dtos.Purchase;
using Data;
using Microsoft.EntityFrameworkCore;

namespace CarsDealerApi.Services.PurchaseService
{
    public class PurchaseService : IPurchaseService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.NameIdentifier)!);
        public PurchaseService(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            
        }
        public async Task<ServiceResponse<GetCarDto>> AddPurchase(AddPurchaseDto newPurchase)
        {
            var response = new ServiceResponse<GetCarDto>();
            try
            {
                var car = await _context.Cars
                    .FirstOrDefaultAsync(car => car.Id == newPurchase.CarId);
                if(car is null)
                {
                    response.Success = false;
                    response.Message = "Car not found.";
                    return response;
                }

                var purchase = _mapper.Map<Purchase>(newPurchase);
                purchase.User = await _context.Users.FirstOrDefaultAsync(user => user.Id == GetUserId());
                purchase.Car = car;

                _context.Purchases.Add(purchase);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetCarDto>(car);
            } 
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetPurchaseDto>>> GetAllPurchase()
        {
            var serviceResponse = new ServiceResponse<List<GetPurchaseDto>>();
            var purchases = await _context.Purchases
                .Where(purchase => purchase.User!.Id == GetUserId( )).ToListAsync();
            serviceResponse.Data = purchases.Select(purchase => _mapper.Map<GetPurchaseDto>(purchase)).ToList();
            return serviceResponse;
        }
    }
}