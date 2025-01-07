using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TreinandoPráticasApi._3___Repositories.Interfaces;

namespace TreinandoPráticasApi._2___Domain.Services
{
    public class TokenService : IToken
    {
        public JwtSecurityToken GenerateAccessToken(IEnumerable<Claim> claims, IConfiguration _config)
        {
            //Reponsável por gerar os tokens com base nas claims fornecidas
            var key = _config.GetSection("JWT").GetValue<string>("SecretKey") ??
                      throw new InvalidOperationException("Invalid secret key");

            var privateKey = Encoding.UTF8.GetBytes(key);

            //Criando as credenciais para acessar o token        //Classe é usada para configurar a chave de assinatura para verificar a autenticidade de tokens JWT
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(privateKey), 
                                         SecurityAlgorithms.HmacSha256Signature);
            
            //Descrição do token a partir da configuração do JSON
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_config.GetSection("JWT")
                                                        .GetValue<double>("TokenValidityInMinutes")),
                Audience = _config.GetSection("JWT")
                                  .GetValue<string>("ValidAudience"),

                Issuer = _config.GetSection("JWT").GetValue<string>("ValidIssuer"),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            return token;
        }

        //Token de atualização que é usado obter um novo token de acesso, onde o Token vai ser armazenado na tabela aspnet users
        public string GenerateRefreshToken()
        {
            var secureRandomBytes = new byte[128];

            using var randomNumberGenerator = RandomNumberGenerator.Create();

            randomNumberGenerator.GetBytes(secureRandomBytes);

            var refreshToken = Convert.ToBase64String(secureRandomBytes);

            return refreshToken;
        }


        //No geral vai receber o token expirado e vai validar
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token, IConfiguration _config)
        {
            var secretKey = _config.GetSection("JWT").GetValue<string>("SecretKey") ??
                                  throw new InvalidOperationException("Invalid secret key");

            //Recebendo o token expirado
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                //Configurando a assinatura do emissor com a chave secreta
                IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(secretKey)),
                //Não valida o tempo de vida do token
                ValidateLifetime = false
            };

            //Manipular o token
            var tokenHandler = new JwtSecurityTokenHandler();

            //Validar o token JWT com base nos parametros de validações
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters,
                                                        //Meio que eu criei uma variável onde a saida da variável tokenValidationParameters vai ir para a securityToken
                                                        out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                                    !jwtSecurityToken.Header.Alg.Equals(
                                     SecurityAlgorithms.HmacSha256,
                                     StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }
    }
}
