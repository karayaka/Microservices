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
        }
    }
}
