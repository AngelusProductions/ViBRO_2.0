using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Vibro.API2.Data;
using Vibro.API2.Entities;

namespace Vibro.API2.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            this._context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(string username, string password)
        {
            using var hmac = new HMACSHA512();

            var user = new User
            {
                UserName = username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}