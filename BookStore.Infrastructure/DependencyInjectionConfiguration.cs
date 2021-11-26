using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Infrastructure.Configuration;
using BookStore.Infrastructure.Configuration.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Infrastructure
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddInfrastructureDependencyConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<IBookStoreConfiguration, BookStoreConfiguration>();
        }

    }
}
