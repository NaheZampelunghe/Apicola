using System.ComponentModel.DataAnnotations;

namespace Apicola.Application.DTOs.Login
{
    public class LoginUserRequestDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}