using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservices.Services.Payment.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservices.Services.Payment.Controllers
{
    //midlewares ware exception handler test edildi dependesy enjection çalışıyopr!

    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {

            //throw new NotFoundException("Text HAtası");

            return Ok();

        }
        [Authorize]
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string value) =>Ok();
        

    }
}

