using System;
using MediatR;
using Microservice.Order.Application.Dtos;
using Microservice.Shared.BaseResults;

namespace Microservice.Order.Application.Queries
{
	public class GetOrderByUserIdQuery:IRequest<ApiResult<List<OrderDto>>>
	{
		public string UserId { get; set; }
	}
}

