using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice.Shared.Dtos;
using Microservice.Shared.Services;
using MicroServices.Services.Basket.Dtos;
using MicroServices.Services.Basket.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroServices.Services.Basket.Controllers
{
    [Route("api/[controller]")]
    public class BasketsController : Controller
    {
        private readonly IBasketService basketService;
        private readonly IIdentityService identityService;

        public BasketsController(IBasketService _basketService, IIdentityService _identityService)
        {
            basketService = _basketService;
            identityService = _identityService;
        }
        // GET api/values/5
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                var basket = await basketService.GetBasket(identityService.GetUser().userId);

                return Ok(new ResponseDto<BasketDto>(basket));
            }
            catch (Exception ex)
            {
                return BadRequest("Bir Hata Oluştu");
            }
        }

        // POST api/values
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody]BasketDto basket)
        {
            try
            {
                basket.UserId = identityService.GetUser().userId;
                var reponse= await basketService.SaveOrUpdate(basket);
                if (!reponse)
                    return BadRequest("Hata Oluştu");

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Bir Hata Oluştu");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete()
        {
            try
            {
                await basketService.Delete(identityService.GetUser().userId);

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

