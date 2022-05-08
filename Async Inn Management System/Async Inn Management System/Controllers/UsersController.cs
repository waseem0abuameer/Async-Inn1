using Async_Inn_Management_System.Models.DTOs;
using Async_Inn_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Async_Inn_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterUserDTO data)
        {
            try
            {
                await _userService.Register(data, this.ModelState);
                return Ok("Registered OK and the user is Add");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
           
            
          
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Authenticaten(LoginDataDTO data)
        {
            var user = await _userService.Authenticate(data);
            if (user != null)
            {
                return user;
            }
            return Unauthorized();
        }

    }
}
