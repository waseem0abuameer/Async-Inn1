using System.ComponentModel.DataAnnotations;

namespace Async_Inn_Management_System.Models.DTOs
{
    public class RegisterUserDTO
    {
        [Required(ErrorMessage = "Please Enter The UserName")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "invalid UserName")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter The Passwoed")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter The EmailAddress")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
