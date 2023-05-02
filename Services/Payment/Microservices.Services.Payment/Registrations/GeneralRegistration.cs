using System;
using MassTransit;

namespace Microservices.Services.Payment.Registrations
{
	public static class GeneralRegistration
	{
        //default port 5672
        public static void RabitMqRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration["RabitMqUrl"], "/", host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });
                });
            });
            //services.AddMassTransitHostedService();//bu satır gereklimi?
        }
    }
}

