using MassTransit;
using MicroServices.Services.Basket.Consumers;
using MicroServices.Services.Basket.Services;
using MicroServices.Services.Basket.Settings;
using Microsoft.Extensions.Options;

namespace MicroServices.Services.Basket.Registrations
{
    public static class GeneralRegistration
    {
        public static void SettingRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RedisSettings>(configuration.GetSection("RedisSettings"));
        }
        public static void ServicesRegistration(this IServiceCollection services)
        {
            services.AddSingleton<RedisService>(sp => 
            {
                var redisSetting=sp.GetRequiredService<IOptions<RedisSettings>>().Value;
                var redis = new RedisService(redisSetting.Host, redisSetting.Port);
                redis.Connect();
                return redis;
            });
            services.AddScoped<IBasketService, BasketService>();
        }
        public static void RabitMqRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<CourseNameChangeEventCounsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration["RabitMqUrl"], "/", host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });
                    //kuyruk oluşuyor
                    cfg.ReceiveEndpoint("course-event-change-name-basket", e =>
                    {
                        e.ConfigureConsumer<CourseNameChangeEventCounsumer>(context);

                    });
                });

            });
        }
    }
}
