using System;
using System.Linq;
using MediatR;
using Microservice.Order.Application.Dtos;
using Microservice.Order.Application.Mapping;
using Microservice.Order.Application.Queries;
using Microservice.Order.Persistence.OrderDataContexts;
using Microservice.Shared.BaseResults;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Order.Application.Handlers
{
	public class GetOrdersByUserIdQueryHandler:IRequestHandler<GetOrderByUserIdQuery,ApiResult<List<OrderDto>>>
	{
        private readonly OrderDataContext context;
        public GetOrdersByUserIdQueryHandler(OrderDataContext _context)
		{
            context = _context;
		}

        public async Task<ApiResult<List<OrderDto>>> Handle(GetOrderByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await context.Orders.Include(i => i.OrderItems).Where(o => o.BuyyerId == request.UserId).ToListAsync();

            if (!orders.Any())
            {
                return new ApiResult<List<OrderDto>>(_Data: new());
            }

            var ordersDto=ObjectMapper.Mapper.Map<List<OrderDto>>(orders);

            return new ApiResult<List<OrderDto>>(_Data: ordersDto); 
        }
    }
}

