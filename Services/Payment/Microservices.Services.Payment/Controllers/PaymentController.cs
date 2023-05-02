using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microservice.Shared.Messages;
using Microservices.Services.Payment.Exceptions;
using Microservices.Services.Payment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservices.Services.Payment.Controllers
{
    //midlewares ware exception handler test edildi dependesy enjection çalışıyopr!

    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private readonly ISendEndpointProvider sendProvider;

        public PaymentController(ISendEndpointProvider _sendProvider)
        {
            sendProvider = _sendProvider;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {

            

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
        public async Task<IActionResult> Post([FromBody]PaymentDto model)
        {
            var send = await sendProvider.GetSendEndpoint(new Uri("queue:create-order-service"));

            var orderCreate = new CreateOrderMessageComment();
            orderCreate.RmqTestMessages = model.RmqMessage;
            ///sipariş detayları burda oluşturulack
            await send.Send(orderCreate);
            return Ok("ödendi");
        }
        

    }
}

