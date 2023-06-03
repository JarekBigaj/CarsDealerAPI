using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsDealerApi.Dtos.User;
using CarsDealerApi.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarsDealerApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetData")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Get() 
        {
            return Ok(await _userService.GetUserData());
        }
        [HttpGet("role")]
        public async Task<ActionResult<ServiceResponse<GetUserRoleDto>>> GetRole() 
        {
            return Ok(await _userService.GetUserRole());
        }
    }
}