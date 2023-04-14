using MicroServices.Services.Basket.Services;
using MicroServices.Services.Basket.Settings;

namespace MicroServices.Services.Basket.Registrations
{
    public static class GeneralRegistration
    {
        public static void SettingRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RedisSettings>(configuration.GetSection("RedisSettings"));
        }
        public static void DbRegistration(this IServiceCollection services)
        {
            services.AddSingleton<RedisService>();
        }
    }
}
