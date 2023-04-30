using System;
namespace Microservice.Order.Application.Dtos
{
	public class OrderItemDto
	{
		public OrderItemDto()
		{
		}
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductUrl { get; set; }

        public Decimal Price { get; set; }

    }
}

