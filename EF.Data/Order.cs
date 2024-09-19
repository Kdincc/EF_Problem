using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data
{
	public sealed class Order
	{
		private readonly List<OrderItem> _items;

		public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
		public OrderId Id { get; private set; }

		public Order(OrderId orderId, List<OrderItem> orders)
		{
			Id = orderId;
			_items = orders ?? new List<OrderItem>();
		}

		private Order()
		{
			_items = new List<OrderItem>();
		}
	}
}
