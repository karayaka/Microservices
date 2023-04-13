using System;
using Microservices.Services.IdentityApi.DataContextes;
using Microservices.Services.IdentityApi.Models;
using Microservices.Services.IdentityApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Services.IdentityApi.Registrations
{
	public static class GeneralRegistration
	{
		public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
		{

            services.AddDbContext<IdentityContext>(options=>
			{
				options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
			services.AddIdentity<AppUser, AppRole>(options=>
			{
				options.Password.RequiredLength = 3;
				options.Password.RequireLowercase = false;
				options.Password.RequireNonAlphanumeric = false;
				
			}).AddEntityFrameworkStores<IdentityContext>()
				.AddDefaultTokenProviders();

			services.AddSingleton<TokenGenerateService>();
		}
	}
}

