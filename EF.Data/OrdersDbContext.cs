using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data
{
	public sealed class OrdersDbContext : DbContext
	{
		public DbSet<Order> Orders { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFCoreDemo;Trusted_Connection=True;");
			optionsBuilder.EnableSensitiveDataLogging();
			optionsBuilder.LogTo(Console.WriteLine, LogLevel.Debug);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Применение конфигураций
			modelBuilder.ApplyConfiguration(new OrderConfiguration());
			modelBuilder.ApplyConfiguration(new OrderItemConfiguration());

		}

		public class OrderConfiguration : IEntityTypeConfiguration<Order>
		{
			public void Configure(EntityTypeBuilder<Order> builder)
			{
				builder.HasKey(o => o.Id);

				builder.Property(o => o.Id)
					.HasConversion(
						v => v.Value, 
						v => OrderId.FromGuid(v)
					)
					.IsRequired();

				builder.HasMany(o => o.Items)
					   .WithOne()
					   .HasForeignKey(oi => oi.OrderId)
					   .OnDelete(DeleteBehavior.Cascade);

				builder.Navigation(o => o.Items)
					   .UsePropertyAccessMode(PropertyAccessMode.Field);
			}
		}

		public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
		{
			public void Configure(EntityTypeBuilder<OrderItem> builder)
			{
				builder.HasKey(oi => oi.Id);

				builder.Property(oi => oi.Id)
					.HasConversion(
						v => v.Value,
						v => OrderItemId.FromGuid(v)
					)
					.IsRequired();

				builder.Property(oi => oi.OrderId)
					.HasConversion(
						v => v.Value, 
						v => OrderId.FromGuid(v) 
					)
					.IsRequired();
			}
		}
	}
}
