using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data
{
	public sealed class OrderItemId
	{
		public Guid Value { get; private set; }

		private OrderItemId(Guid guid)
		{
			Value = guid;
		}

		public static OrderItemId CreateUnique()
					{
			return new OrderItemId(Guid.NewGuid());
		}

		public static OrderItemId FromGuid(Guid guid)
		{
			return new OrderItemId(guid);
		}
	}
}
