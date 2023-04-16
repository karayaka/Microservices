using System;
namespace Microservice.Shared.Dtos
{
	public class SessionDto
	{
		public SessionDto()
		{
		}
		public string userId { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }

		public string Email { get; set; }
	}
}

