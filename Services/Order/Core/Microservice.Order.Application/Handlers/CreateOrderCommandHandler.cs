using System;
using MediatR;
using Microservice.Order.Application.Commands;
using Microservice.Order.Application.Dtos;
using Microservice.Shared.BaseResults;

namespace Microservice.Order.Application.Handlers
{
	public class CreateOrderCommandHandler:IRequestHandler<OrderCrateCommands, ApiResult<CreatedOrderDto>>
	{
		public CreateOrderCommandHandler()
		{
		}

        public Task<ApiResult<CreatedOrderDto>> Handle(OrderCrateCommands request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

