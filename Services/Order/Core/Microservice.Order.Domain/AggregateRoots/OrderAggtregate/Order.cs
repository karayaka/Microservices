using System;
using System.Diagnostics;
using Microservice.Order.Domain.Entitys;

namespace Microservice.Order.Domain.AggregateRoots.OrderAggtregate
{
	public class Order:BaseEntity,IAggregateRoot
	{
		public DateTime CreatedDate { get; private set; }

		public Adress Adress { get; private set; }

		public string BuyyerId { get; private set; }

		private readonly List<OrderItem> _orderItems;

		public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public Order(string _BuyyerId, Adress _Adress)
        {
            _orderItems = new List<OrderItem>();
            CreatedDate = DateTime.UtcNow;
            BuyyerId = _BuyyerId;
            Adress = _Adress;
        }

        public void AddOrderItem(string _ProductId, string _ProductName, string _ProductUrl, Decimal _Price)
        {
            var exsistProduct = _orderItems.Any(t => t.ProductId == _ProductId);
            if(!exsistProduct)
                _orderItems.Add(new(_ProductId,_ProductName,_ProductUrl,_Price));
        }

        public decimal GetTotalPrice => _orderItems.Sum(s => s.Price);

    }
}

