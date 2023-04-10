using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservices.Services.IdentityApi.Dtos.UserModels;
using Microservices.Services.IdentityApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservices.Services.IdentityApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;//identity kütüp hanesi jwt ve diğer servislere jwt entegrasyonu yaılacak!!
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        //register mtodu
        [HttpPost]
        public async Task<IActionResult> Post(UserCreateDto model)
        {
            try
            {
                var results= await _userManager.CreateAsync(new()
                {
                    UserName = model.UserName,
                    Name=model.Name,
                    Surname=model.Surname,
                    Email=model.Email,

                },password:model.Password);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Bir Hata");
            }
        }

        // PUT api/values/5
        //Kuşşanıcı Güncelle ve sil metodları yaılabilir
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

