using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Infrastructure;

namespace BookStore.Domain.Order.DomainServices.Interfaces
{
    public interface IOrderService
    {
        Task<Result<List<BookStore.Entities.Order.Order>>> GetOrders();
        Task<Result> SubmitOrder(BookStore.Entities.Order.Order order);
    }
}
