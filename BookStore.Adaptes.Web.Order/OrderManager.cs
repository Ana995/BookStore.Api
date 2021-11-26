using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Adaptes.Web.Order.Mappers.ToDomain;
using BookStore.Adaptes.Web.Order.Mappers.ToWeb;
using BookStore.Domain.Order.DomainServices.Interfaces;
using BookStore.Infrastructure;
using BookStore.Ports.Web.Order.Interfaces;
using BookStore.Ports.Web.Order.Model.Request;

namespace BookStore.Adaptes.Web.Order
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderService orderService;
        public OrderManager(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public Task<Result<List<Ports.Web.Order.Model.Response.Order>>> GetOrders()
        {
            return this.orderService.GetOrders().Map(order => order.ToWeb());
        }

        public Task<Result> SubmitOrder(OrderRequest order)
        {
            return this.orderService.SubmitOrder(order.ToDomain());
        }

    }
}
