using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Infrastructure;
using BookStore.Ports.DataAccess.BooksCatalog.Interfaces;
using BookStore.Ports.DataAccess.BooksCatalog.Model.Response;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.Server.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Components.Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookManager bookManager;

        [HttpGet]
        public async Task<Result<List<Book>>> Get()
        {
            var result = await this.bookManager.GetBooks();
            return result;
        }
    }
}