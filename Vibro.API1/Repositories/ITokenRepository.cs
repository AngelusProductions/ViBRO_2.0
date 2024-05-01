using Microsoft.AspNetCore.Identity;

namespace Vibro.API1.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
