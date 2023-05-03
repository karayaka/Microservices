using System;
using MassTransit;
using Microservice.Shared.Messages;
using MicroServices.Services.Basket.Dtos;
using MicroServices.Services.Basket.Services;

namespace MicroServices.Services.Basket.Consumers
{
	public class CourseNameChangeEventCounsumer: IConsumer<CourseNameChangeEvent>
    {
        private readonly ILogger<CourseNameChangeEventCounsumer> logger;
        private readonly IBasketService basketService;
        public CourseNameChangeEventCounsumer(ILogger<CourseNameChangeEventCounsumer> _logger, IBasketService _basketService)
        {
            logger = _logger;
            basketService = _basketService;
        }

        public async Task Consume(ConsumeContext<CourseNameChangeEvent> context)
        {
            logger.LogInformation(context.Message.CourseId + " basket -- " + context.Message.UpdatedName);
            var basket = new BasketDto();
            //await basketService.SaveOrUpdate(basket);
            //basekt güncelleem işlemelri yapıır

        }
    }
}

