using System.ComponentModel.DataAnnotations;

namespace Async_Inn_Management_System.Models.DTOs
{
    public class LoginDataDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
