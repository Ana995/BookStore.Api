using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Infrastructure.Configuration.Interfaces;
using Microsoft.Extensions.Configuration;

namespace BookStore.Infrastructure.Configuration
{

    public class BookStoreConfiguration: IBookStoreConfiguration
    {

        private readonly IConfiguration _configuration;

        public BookStoreConfiguration(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public string ConnectionString  => _configuration.GetConnectionString("DefaultConnection");
    }
}
