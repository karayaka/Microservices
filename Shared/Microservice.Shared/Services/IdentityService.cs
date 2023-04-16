using System;
using System.Security.Claims;
using Microservice.Shared.Dtos;
using Microsoft.AspNetCore.Http;

namespace Microservice.Shared.Services
{
	public class IdentityService:IIdentityService
	{
		private readonly IHttpContextAccessor httpContextAccesor;
		public IdentityService(IHttpContextAccessor _httpContextAccesor)
		{
			httpContextAccesor = _httpContextAccesor;
		}

        public SessionDto GetUser()
        {
			try
			{
				var user = httpContextAccesor.HttpContext.User;


                SessionDto sesion = new();
				var userId = user.FindFirst(ClaimTypes.NameIdentifier);
				if (userId == null)
					throw new Exception("User Claim Not Fount");
                sesion.userId = userId.Value.ToString();
				sesion.Name = user.FindFirst(ClaimTypes.Name).Value.ToString();
                sesion.Surname = user.FindFirst(ClaimTypes.Surname).Value.ToString();
                sesion.Email = user.FindFirst(ClaimTypes.Email).Value.ToString();
				return sesion;
            }
			catch (Exception ex)
			{
				throw ex;
			}
        }
    }
}

