using System;
using Microservice.Order.Domain.Entitys;

namespace Microservice.Order.Domain.AggregateRoots.OrderAggtregate
{
	public class OrderItem:BaseEntity
	{
		public OrderItem(string _ProductId,string _ProductName,string _ProductUrl,Decimal _Price)
		{
			ProductId = _ProductId;
			ProductName = _ProductName;
			ProductUrl = _ProductUrl;
			Price = _Price;
        }
		public string ProductId { get; private set; }

		public string ProductName { get; private set; }

		public string ProductUrl { get; private set; }

		public Decimal Price { get; private set; }



		public void UpdateOrderItem(string _ProductName, string _ProductUrl, Decimal _Price)
		{
            ProductName = _ProductName;
            ProductUrl = _ProductUrl;
            Price = _Price;
        }

	}
}

