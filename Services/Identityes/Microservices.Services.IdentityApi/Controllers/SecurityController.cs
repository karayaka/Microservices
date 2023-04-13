using Microservices.Services.IdentityApi.Dtos.UserModels;
using Microservices.Services.IdentityApi.Models;
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

        public SecurityController(SignInManager<AppUser> _signInManager)
        {
            signInManager= _signInManager;
        }

        public async Task<IActionResult> Login(LoginDto model)
        {
            try
            {

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Hata");
            }
        }
    }
}
