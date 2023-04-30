using System;
using Microservice.Order.Domain.AggregateRoots.OrderAggtregate;

namespace Microservice.Order.Application.Dtos
{
	public class OrderDto
	{
		public OrderDto()
		{
		}

		public int  Id { get; set; }

		public DateTime CreatedDate { get; private set; }

        public AdressDto Adress { get; private set; }

        public string BuyyerId { get; private set; }

		public List<OrderItemDto> OrderItems { get; set; }
	}
}

