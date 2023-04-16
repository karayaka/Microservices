using System;
using Microservice.Shared.Dtos;

namespace Microservice.Shared.Services
{
	public interface IIdentityService
	{
        SessionDto GetUser();
    }
}

