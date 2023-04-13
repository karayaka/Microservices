using System;
using Microservices.Services.IdentityApi.Dtos.BaseModels;

namespace Microservices.Services.IdentityApi.Dtos.SecurityModels
{
	public class LoginDTO: BaseDto
    {
		public LoginDTO()
		{
		}

		public string UserName { get; set; }

		public string Password { get; set; }

	}
}

