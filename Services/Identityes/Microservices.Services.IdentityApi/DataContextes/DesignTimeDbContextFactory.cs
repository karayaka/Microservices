using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Microservices.Services.IdentityApi.DataContextes
{
	public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<IdentityContext>
    {
		public DesignTimeDbContextFactory()
		{
		}

        public IdentityContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<IdentityContext>();

            var connectionString = "User ID=admin;Password=55315531;Server=localhost;Port=5432;Database=identityDb;Integrated Security=true;Pooling=true;";
            builder.UseNpgsql(connectionString);

            return new IdentityContext(builder.Options);
        }
    }
}

