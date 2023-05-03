using System;
using Microservice.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using MassTransit;
using Microservice.Order.Application.Consumers;

namespace Microservice.Order.Application.Registrations
{
	public static class AplicationRegistration
	{
        public static void RabitMqRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<CreateOrderMessageCommentConsumer>();
                x.AddConsumer<CourseNameChangeEventCounsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration["RabitMqUrl"], "/", host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });

                    cfg.ReceiveEndpoint("create-order-service", e =>
                    {
                        e.ConfigureConsumer<CreateOrderMessageCommentConsumer>(context);

                    });
                    cfg.ReceiveEndpoint("course-event-change-name", e =>
                    {
                        e.ConfigureConsumer<CourseNameChangeEventCounsumer>(context);

                    });
                });
            });
        }
    }
}

