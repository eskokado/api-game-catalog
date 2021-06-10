using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using Api.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private IPlayerRepository _repository;

        private SigningConfigurations _signingConfigurations;

        private IConfiguration _configuration { get; }

        public LoginService(
            IPlayerRepository repository,
            SigningConfigurations signingConfigurations,
            IConfiguration configuration
        )
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _configuration = configuration;
        }

        public async Task<object> FindByLogin(LoginDto player)
        {
            var basePlayer = new PlayerEntity();
            if (player != null && !string.IsNullOrWhiteSpace(player.Email))
            {
                basePlayer = await _repository.FindByLogin(player.Email);
                if (basePlayer == null)
                {
                    return new {
                        authenticated = false,
                        message = "Falha ao autenticar"
                    };
                }
                else
                {
                    ClaimsIdentity identity =
                        new ClaimsIdentity(new GenericIdentity(basePlayer.Email),
                            new []
                            {
                                new Claim(JwtRegisteredClaimNames.Jti,
                                    Guid.NewGuid().ToString()),
                                new Claim(JwtRegisteredClaimNames.UniqueName,
                                    player.Email)
                            });
                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate =
                        createDate +
                        TimeSpan.FromSeconds(Convert.ToInt32(Environment.GetEnvironmentVariable("Seconds")));
                    var handler = new JwtSecurityTokenHandler();
                    string token =
                        CreateToken(identity,
                        createDate,
                        expirationDate,
                        handler);
                    return SuccessObject(createDate,
                    expirationDate,
                    token,
                    basePlayer);
                }
            }
            else
            {
                return new {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }

        private string
        CreateToken(
            ClaimsIdentity identity,
            DateTime createDate,
            DateTime expirationDate,
            JwtSecurityTokenHandler handler
        )
        {
            var securityToken =
                handler
                    .CreateToken(new SecurityTokenDescriptor {
                        Issuer = Environment.GetEnvironmentVariable("Issuer"),
                        Audience = Environment.GetEnvironmentVariable("Audience"),
                        SigningCredentials =
                            _signingConfigurations.SigningCredentials,
                        Subject = identity,
                        NotBefore = createDate,
                        Expires = expirationDate
                    });
            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object
        SuccessObject(
            DateTime createDate,
            DateTime expirationDate,
            string token,
            PlayerEntity player
        )
        {
            return new {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                playerName = player.Email,
                name = player.Name,
                message = "Jogador logado com sucesso"
            };
        }
    }
}
