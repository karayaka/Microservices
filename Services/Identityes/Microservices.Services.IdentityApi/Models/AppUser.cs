using System;
using Microsoft.AspNetCore.Identity;

namespace Microservices.Services.IdentityApi.Models
{
	public class AppUser:IdentityUser<Guid>
	{
		public AppUser()
		{
		}
		public string Name { get; set; }

		public string Surname { get; set; }
	}
}

