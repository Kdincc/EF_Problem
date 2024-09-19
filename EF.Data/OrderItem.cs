using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data
{
	public sealed class OrderItem
	{
        public OrderId OrderId { get; private set; }

		public OrderItemId Id { get; private set; }

        public OrderItem(OrderItemId orderItemId, OrderId orderId)
        {
            Id = orderItemId;
            OrderId = orderId;
        }

        private OrderItem()
		{
		}
    }
}
