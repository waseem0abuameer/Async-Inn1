using Async_Inn_Management_System.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace Async_Inn_Management_System.Models.Interfaces
{
    public interface IUserService
    {
        public Task<UserDTO> Register(RegisterUserDTO data, ModelStateDictionary modelState);
       
        public Task<UserDTO> Authenticate(LoginDataDTO data);
    }
}
