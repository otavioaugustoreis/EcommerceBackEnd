using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Web.Http;
using TreinandoPráticasApi._1___Application.Models;
using TreinandoPráticasApi._3___Repositories.Interfaces;
using TreinandoPráticasApi._4__Data.Entities;
using Microsoft.AspNetCore.Mvc;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
//using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;

namespace TreinandoPráticasApi.Controllers
{

    [Route("/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IToken _token;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(IToken token,
                              UserManager<ApplicationUser> userManager,
                              RoleManager<IdentityRole> roleManager,
                              IConfiguration configuration)
        {
            _token = token;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([Microsoft.AspNetCore.Mvc.FromBody] LoginModel model)
        {
            // Validação básica do modelo
            if (model == null || string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest("Nome de usuário ou senha inválidos.");
            }

            // Localizar o usuário na tabela de usuários do Identity
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                // Obtendo os perfis do usuário
                var userRoles = await _userManager.GetRolesAsync(user);

                // Criação da lista de claims
                var authClaims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

                // Adicionando as roles às claims
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                // Gerando o token de acesso
                var token = _token.GenerateAccessToken(authClaims, _configuration);
                var refreshToken = _token.GenerateRefreshToken();

                // Tentando parsear o tempo de validade do refresh token
                if (!int.TryParse(_configuration["JWT:RefreshTokenValidityInMinutes"], out int refreshTokenValidityInMinutes))
                {
                    refreshTokenValidityInMinutes = 30; // Valor padrão
                }

                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(refreshTokenValidityInMinutes);

                // Atualizando o usuário
                await _userManager.UpdateAsync(user);

                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken = refreshToken,
                    Expiration = token.ValidTo
                });
            }
            //401 - não autorizado
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.UserName!);

            if (userExists != null)
            {
                return StatusCode(500, new Response
                {
                    Status = "Error",
                    Message = "User already exists!"
                });
            }

            ApplicationUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
            };
            var result = await _userManager.CreateAsync(user, model.Password!);

            if (!result.Succeeded)
            {
                return StatusCode(500, new Response
                {
                    Status = "Error",
                    Message = "User creation failed."
                });
            }

            return Ok(new Response
            {
                Status = "Success",
                Message = "User created successfully!"
            });
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<ActionResult> RefreshToken(TokenModel tokenModel)
        {
            if (tokenModel is null)
            {
                return BadRequest("Invalid client request");
            }

            //Pegando o acesso do token
            string? accessToken = tokenModel.AccessToken
                                            ?? throw new ArgumentException(nameof(tokenModel));

            string? refreshToken = tokenModel.RefreshToken
                                            ?? throw new ArgumentException(nameof(tokenModel));

            //Aqui ele me retorna as claims do token expirado para dar o refresh
            var principal = _token.GetPrincipalFromExpiredToken(accessToken!, _configuration);

            if (principal is null)
            {
                return BadRequest("Invalid access token/refresh token");
            }

            string username = principal.Identity.Name;

            var user = await _userManager.FindByNameAsync(username!);
            //Verifico se o usuário existe e se o redresh token informado com o refresh token que está armazenado na tabela do usuário e tem que ser um refresh token que não expirou
            if (user is null || user.RefreshToken != refreshToken
                             || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return BadRequest("Invalid accces token/refresh token");
            }

            //Gerando um novo token de acesso
            var newAccessToken = _token.GenerateAccessToken(
                                        principal.Claims.ToList(), _configuration);

            //Gerando um novo refresh token
            var newRefreshToken = _token.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            return new ObjectResult(new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                refreshToken = newRefreshToken
            });
        }

        [Authorize]
        [HttpPost]
        [Route("revoke/{username}")]
        //Método para revogar o nome do usuário
        public async Task<ActionResult> Revoke(string username)
        {

            var user = await _userManager.FindByNameAsync(username);

            if (user is null) return BadRequest("Invalid user name");
            
            //Deixando null o refresh token
            user.RefreshToken = null;

            await _userManager.UpdateAsync(user);

            return NoContent();
        }

        }
    }
