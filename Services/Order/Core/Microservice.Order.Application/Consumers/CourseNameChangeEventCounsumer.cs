using System;
using MassTransit;
using Microservice.Shared.Messages;
using Microsoft.Extensions.Logging;

namespace Microservice.Order.Application.Consumers
{
	public class CourseNameChangeEventCounsumer:IConsumer<CourseNameChangeEvent>
	{
        private readonly ILogger<CourseNameChangeEventCounsumer> logger;
        public CourseNameChangeEventCounsumer(ILogger<CourseNameChangeEventCounsumer> _logger)
		{
            logger = _logger;
		}

        public async Task Consume(ConsumeContext<CourseNameChangeEvent> context)
        {
            logger.LogInformation(context.Message.CourseId +" order -- "+ context.Message.UpdatedName);
        }
    }
}

