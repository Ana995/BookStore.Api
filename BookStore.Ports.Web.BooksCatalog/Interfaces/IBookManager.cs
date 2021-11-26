using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Infrastructure;
using BookStore.Ports.Web.BooksCatalog.Model.Response;
using Refit;

namespace BookStore.Ports.Web.BooksCatalog.Interfaces
{
    public interface IBookManager
    {
        [Get("/api/v1/products")]
        Task<Result<List<Book>>> GetBooks();
    }
}
