using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Microservice.Order.Persistence.OrderDataContexts
{
	public class DesignTimeDbContextFactory:IDesignTimeDbContextFactory<OrderDataContext>
	{
		public DesignTimeDbContextFactory()
		{

        }

        public OrderDataContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<OrderDataContext>();

            var connectionString = "User ID=admin;Password=55315531;Server=localhost;Port=5432;Database=OrderDb;Integrated Security=true;Pooling=true;";
            builder.UseNpgsql(connectionString);

            return new OrderDataContext(builder.Options);
        }
    }
}

