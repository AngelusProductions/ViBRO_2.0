using System.ComponentModel.DataAnnotations;

namespace Vibro.API2.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}