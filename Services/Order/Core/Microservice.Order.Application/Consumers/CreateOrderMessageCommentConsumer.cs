using System;
using MassTransit;
using Microservice.Shared.Messages;
using Microsoft.Extensions.Logging;

namespace Microservice.Order.Application.Consumers
{
	public class CreateOrderMessageCommentConsumer:IConsumer<CreateOrderMessageComment>
	{
        private readonly ILogger<CreateOrderMessageCommentConsumer> logger;

		public CreateOrderMessageCommentConsumer(ILogger<CreateOrderMessageCommentConsumer> _logger)
		{
            logger = _logger;
		}

        public async Task Consume(ConsumeContext<CreateOrderMessageComment> context)
        {
            logger.LogInformation(context.Message.RmqTestMessages);
        }
    }
}

