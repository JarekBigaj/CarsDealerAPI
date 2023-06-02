using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsDealerApi.Dtos.User;

namespace CarsDealerApi.Services.User
{
    public interface IUserService
    {
        Task<ServiceResponse<GetUserDto>> UdpdateUserData(GetUserDto updatedUserData);
        Task<ServiceResponse<GetUserDto>> GetUserData();
    }
}