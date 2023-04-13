using Microservice.Shared.Dtos;
using Microservices.Services.IdentityApi.Dtos.SecurityModels;
using Microservices.Services.IdentityApi.Dtos.UserModels;
using Microservices.Services.IdentityApi.Models;
using Microservices.Services.IdentityApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Services.IdentityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly TokenGenerateService tS;

        public SecurityController(SignInManager<AppUser> _signInManager, UserManager<AppUser> _userManager, TokenGenerateService _tS)
        {
            signInManager = _signInManager;
            userManager = _userManager;
            tS = _tS;
        }

        public async Task<IActionResult> Login(LoginDto model)
        {
            try
            {
                var user = await userManager.FindByNameAsync(model.UserName);
                if (user == null)
                    user = await userManager.FindByEmailAsync(model.UserName);
                if (user == null)
                    return Unauthorized("Kuşşanıcı Adı Veya Şifre Hatalı");
                var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                if (result.Succeeded)
                {
                    var exDate = DateTime.Now.AddDays(2);
                    var response = new LoginResponseDTO()
                    {
                        ExpireDate = exDate,
                        Id = user.Id,
                        Name = user.Name,
                        Surname = user.Surname,
                        Token = tS.JWTTokenGenerate(new()
                        {
                            Email = user.Email,
                            Surname = user.Surname,
                            Name = user.Name,
                        }, exDate)
                    };
                    return Ok(new ResponseDto<LoginResponseDTO>(response));
                }
                return Unauthorized("Kuşşanıcı Adı Veya Şifre Hatalı");
            }
            catch (Exception ex)
            {
                return BadRequest("Hata");
            }
        }
    }
}
