using System;
using Microservices.Services.IdentityApi.Dtos.BaseModels;

namespace Microservices.Services.IdentityApi.Dtos.UserModels
{
	public class UserCreateDto:BaseDto
	{
		public UserCreateDto()
		{
		}
		public string UserName { get; set; }

		public string Password { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }

		public string Email { get; set; }
	}
}

