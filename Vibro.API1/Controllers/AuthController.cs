using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vibro.API1.Models.DTO;
using Vibro.API1.Repositories;

namespace Vibro.API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository, ILogger logger) : ControllerBase
    {
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            logger.LogInformation("Registering new user");

            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (!identityResult.Succeeded) return BadRequest(identityResult.Errors);
            if (registerRequestDto.Roles.Length == 0) return BadRequest(identityResult.Errors);

            identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

            if (identityResult.Succeeded)
                return Ok("User was registered. Please login!");

            return BadRequest(identityResult.Errors);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            logger.LogInformation("Logging in user");

            var user = await userManager.FindByEmailAsync(loginRequestDto.Username);
            if (user == null) return BadRequest("User not found!");

            var isPasswordCorrect = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);
            if (!isPasswordCorrect) return BadRequest("Invalid password!");

            var roles = await userManager.GetRolesAsync(user);

            var jwtToken = tokenRepository.CreateJWTToken(user, [.. roles]);
            var response = new LoginResponseDto()
            {
                JwtToken = jwtToken
            };

            return Ok(response);
        }
    }
}
