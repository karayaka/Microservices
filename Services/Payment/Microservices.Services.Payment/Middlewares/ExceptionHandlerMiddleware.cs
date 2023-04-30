using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mime;
using Microservices.Services.Payment.Dtos;
using Microservices.Services.Payment.Exceptions;

namespace Microservices.Services.Payment.Middlewares
{
	public class ExceptionHandlerMiddleware
	{
		private readonly RequestDelegate next;

		private readonly ILogger<ExceptionHandlerMiddleware> logger;
		public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
		{
			this.next = next;
			this.logger = logger;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				//request loging
                await next.Invoke(context);
            }
			catch (Exception eror)
			{
				logger.LogInformation(eror.Message);
                context.Response.ContentType = MediaTypeNames.Application.Json;
				if (eror is UnAuthorizedException)
					context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                else if (eror is NotFoundException)				
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                else if (eror is ValidationException)
                    context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                else
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync(new ErrorResponse(eror.Message));
            }
			
		}

	}
}

