using System;
using Microservices.Services.IdentityApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Services.IdentityApi.DataContextes
{
	public class IdentityContext:IdentityDbContext<AppUser,AppRole,Guid>
	{
		public IdentityContext(DbContextOptions options) : base(options)
		{
		}
	}
}

