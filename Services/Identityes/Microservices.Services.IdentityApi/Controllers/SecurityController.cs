using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservices.Services.IdentityApi.Dtos.SecurityModels;
using Microservices.Services.IdentityApi.Models;
using Microservices.Services.IdentityApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservices.Services.IdentityApi.Controllers
{
    [Route("api/[controller]")]
    public class SecurityController : Controller
    {
        private readonly SignInManager<AppUser> singInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly TokenGenerateService tS;
        

        public SecurityController(SignInManager<AppUser>_singInManager, UserManager<AppUser> _userManager,TokenGenerateService _tS)
        {
            singInManager = _singInManager;
            userManager = _userManager;
            tS = _tS;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginDTO model)
        {
            try
            {
                var user = await userManager.FindByNameAsync(model.UserName);
                if (user == null)
                    user = await userManager.FindByEmailAsync(model.UserName);
                if (user == null)
                    return Unauthorized("Kullanıcı Bulunamadı");

                var result = await singInManager.CheckPasswordSignInAsync(user, model.Password,false);

                if (result.Succeeded)
                {
                    var exDate = DateTime.Now.AddDays(10);
                    var token= tS.JWTTokenGenerate(new()
                    {
                        Id=user.Id,
                        Name=user.Name,
                        Email=user.Email,
                        Surname=user.Surname,
                    }, exDate);
                }
                else
                    return Unauthorized("Kullanıcı Bulunamadı");


                return Ok();
            }
            catch (Exception ex)
            {
                return Unauthorized("Giriş İşlemi Sırsında Hata oldu");
            }
        }
    }
}

