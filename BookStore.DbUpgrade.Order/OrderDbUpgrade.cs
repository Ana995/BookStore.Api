using System;
using System.Reflection;
using DbUp;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.DbUpgrade.Order
{
    public static class OrderDbUpgrade
    {
        public static int OrderDbUp(this IServiceCollection services, string connectionString)
        {
            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                return -1;
            }

            return 0;
        }
    }
}

