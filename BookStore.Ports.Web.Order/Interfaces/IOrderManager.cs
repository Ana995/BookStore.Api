using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Infrastructure;
using BookStore.Ports.Web.Order.Model.Request;
using Refit;

namespace BookStore.Ports.Web.Order.Interfaces
{
    public interface IOrderManager
    {
        [Get("/api/v1/order")]
        Task<Result<List<Model.Response.Order>>> GetOrders();

        [Post("/api/v1/order")]
        Task<Result> SubmitOrder([Body] OrderRequest order);
    }
}
