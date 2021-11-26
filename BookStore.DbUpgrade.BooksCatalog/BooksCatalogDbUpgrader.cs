using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using DbUp;

namespace BookStore.DbUpgrade.BooksCatalog
{
    public static class BooksCatalogDbUpgrader
    {
        public static int BooksCatalogDb(this IServiceCollection services, string connectionString)
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
