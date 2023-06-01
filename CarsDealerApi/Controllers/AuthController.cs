using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using CarsDealerApi.Data;
using Microsoft.AspNetCore.Mvc;
using CarsDealerApi.Dtos.User;
using CarsDealerApi.Model;

namespace CarsDealerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
            
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response = await _authRepo.Register(
                new User { Email = request.Email }, request.Password
            );
            if(!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(UserRegisterDto request)
        {
            var response = await _authRepo.Login( request.Email, request.Password);
            if(!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}