using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TreinandoPráticasApi._3___Repositories.Interfaces
{
    public interface IToken
    {
        JwtSecurityToken GenerateAccessToken(IEnumerable<Claim> claims,
                                             IConfiguration _config);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token,
                                                     IConfiguration _config);
    }
}
