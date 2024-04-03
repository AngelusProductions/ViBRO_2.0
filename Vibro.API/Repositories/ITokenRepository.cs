using Microsoft.AspNetCore.Identity;

namespace Vibro.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
