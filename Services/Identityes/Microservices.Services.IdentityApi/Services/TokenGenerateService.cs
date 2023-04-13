using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microservices.Services.IdentityApi.Dtos.UserModels;

namespace Microservices.Services.IdentityApi.Services
{
	public class TokenGenerateService
	{
        private readonly IConfiguration config;
        public TokenGenerateService(IConfiguration _config)
        {
            config = _config;
		}

        public string JWTTokenGenerate(UserCreateDto user, DateTime expiredDate)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(config["AppSettings:Token"]);
                var tokenDecriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                   {
                       new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                       new Claim(ClaimTypes.Name, user.Name),
                       new Claim(ClaimTypes.Surname, user.Surname),
                       new Claim(ClaimTypes.Email, user.Email),
                   }),
                    Expires = expiredDate,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                   SecurityAlgorithms.HmacSha512Signature)
                };
                var token = tokenHandler.CreateToken(tokenDecriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

