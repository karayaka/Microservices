using System;
using MediatR;
using Microservice.Order.Application.Dtos;
using Microservice.Shared.BaseResults;

namespace Microservice.Order.Application.Commands
{
	public class OrderCrateCommands:IRequest<ApiResult<CreatedOrderDto>>
	{
		public OrderCrateCommands()
		{
		}
		public string BuyyerId { get; set; }

		public List<OrderItemDto> OrderItems { get; set; }

		public AdressDto Adress { get; set; }
	}
}

