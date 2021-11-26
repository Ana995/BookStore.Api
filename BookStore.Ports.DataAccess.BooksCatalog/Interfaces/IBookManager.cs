using System;
using System.Collections.Generic;
using Refit;
using System.Threading.Tasks;
using BookStore.Infrastructure;
using BookStore.Ports.DataAccess.BooksCatalog.Model.Response;

namespace BookStore.Ports.DataAccess.BooksCatalog.Interfaces
{
    public interface  IBookManager
    {
        [Get("/api/v1/products")]
        Task<Result<List<Book>>> GetBooks();
    }
}
