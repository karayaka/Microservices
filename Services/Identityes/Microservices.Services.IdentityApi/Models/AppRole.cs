using System;
using Microsoft.AspNetCore.Identity;

namespace Microservices.Services.IdentityApi.Models
{
	public class AppRole:IdentityRole<Guid>
    {
		public AppRole()
		{
		}
	}
}

