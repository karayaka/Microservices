using System;
using System.Reflection;
using Microservices.Services.Catolog.Configs;
using Microservices.Services.Catolog.Services;
using Microsoft.Extensions.Options;

namespace Microservices.Services.Catolog.Rgistrations
{
	public static class Registrations
	{
		public static void MapperRegistration(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
		}

        public static void Config(this IServiceCollection services,IConfiguration configuration)
        {
			services.Configure<DatabaseSetting>(configuration.GetSection("DatabaseSetting"));
        }

        public static void ServicesRegistration(this IServiceCollection services)
        {
            services.AddSingleton<DatabaseSetting>(sp =>
            {
                return sp.GetRequiredService<IOptions<DatabaseSetting>>().Value;
            });
            services.AddScoped<ICouseService, CourseService>();
            services.AddScoped<ICategoryService, CategoryService>();

        }
    }
}

