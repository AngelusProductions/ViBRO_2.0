using System.ComponentModel.DataAnnotations;

namespace Vibro.API.Models.DTO
{
    public class LoginRequestDto
    {
        [DataType(DataType.EmailAddress)]
        public required string Username { get; set; }

        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
