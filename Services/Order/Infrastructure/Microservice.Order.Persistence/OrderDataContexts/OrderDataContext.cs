using System;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Order.Persistence.OrderDataContexts
{
	public class OrderDataContext:DbContext
	{
		public const string DEFAULT_SCHEMA = "ordering";
		public OrderDataContext(DbContextOptions options):base(options)
		{

		}
		public DbSet<Order.Domain.AggregateRoots.OrderAggtregate.Order> Orders { get; set; }

		public DbSet<Order.Domain.AggregateRoots.OrderAggtregate.OrderItem> MyProperty { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Order.Domain.AggregateRoots.OrderAggtregate.Order>().ToTable("Orders", DEFAULT_SCHEMA);
            modelBuilder.Entity<Order.Domain.AggregateRoots.OrderAggtregate.OrderItem>().ToTable("OrdersItems", DEFAULT_SCHEMA);
			modelBuilder.Entity<Order.Domain.AggregateRoots.OrderAggtregate.OrderItem>().Property(x => x.Price).HasColumnType("decimal(18,2)");
			modelBuilder.Entity<Order.Domain.AggregateRoots.OrderAggtregate.Order>().OwnsOne(o => o.Adress).WithOwner();

            base.OnModelCreating(modelBuilder);
        }
    }
}

