using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CarsDealerApi.Dtos.User;
using Data;
using Microsoft.EntityFrameworkCore;

namespace CarsDealerApi.Services.User
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IMapper mapper, DataContext context,IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _mapper = mapper;
            
        }
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.NameIdentifier)!);
        public async Task<ServiceResponse<GetUserDto>> GetUserData()
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            var user = await _context.Users
                .FirstOrDefaultAsync(user => user.Id == GetUserId());
            serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            return serviceResponse;
        }

        public Task<ServiceResponse<GetUserDto>> UdpdateUserData(GetUserDto updatedUserData)
        {
            throw new NotImplementedException();
        }
    }
}