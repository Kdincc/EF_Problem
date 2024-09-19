using EF.Data;
using Microsoft.EntityFrameworkCore;

namespace EF
{
	internal class Program
	{
		static void Main(string[] args)
		{

			OrderId orderId = OrderId.CreateUnique();

			OrderItem orderItem = new OrderItem(OrderItemId.CreateUnique(), orderId);

			Order order = new Order(orderId, new List<OrderItem> { orderItem });

			using OrdersDbContext context = new OrdersDbContext();

			context.Orders.RemoveRange(context.Orders);

			context.SaveChanges();

			context.Orders.Add(order);

			context.SaveChanges();

			var orders = context.Orders.Include(o => o.Items).ToList();

			foreach (var item in orders)
			{
				Console.WriteLine($"Order: {item.Id}");
				foreach (var itemOrder in item.Items)
				{
					Console.WriteLine($"OrderItem: {itemOrder.Id}");
				}

			}
		}
	}
}
