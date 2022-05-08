using System.ComponentModel.DataAnnotations;

namespace Async_Inn_Management_System.Models
{
    public class RegisterUser
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
