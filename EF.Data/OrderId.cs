using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data
{
	public sealed class OrderId
	{
		public Guid Value { get; private set; }

		private OrderId(Guid guid)
		{
			Value = guid;
		}

		public static OrderId CreateUnique()
		{
			return new OrderId(Guid.NewGuid());
		}

		public static OrderId FromGuid(Guid guid)
		{
			return new OrderId(guid);
		}
	}
}
