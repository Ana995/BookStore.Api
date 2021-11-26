using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Infrastructure;

namespace BookStore.Ports.DataAccess.Order.DataAccess
{
    public interface IOrderRepository
    {
        Task<Result<List<Entities.Order.Order>>> GetOrders(Guid userId);
        Task<Result> SubmitOrder(Entities.Order.Order order);
    }
}
