using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Order.DomainServices.Interfaces;
using BookStore.Infrastructure;
using BookStore.Infrastructure.UserContext;

namespace BookStore.Domain.Order.DomainServices
{
    internal class OrderService: IOrderService
    {
        private readonly IOrderRepository orderRepository;

        //private readonly IInteropCartManager interopCatalogManager
        //private IInteropCatalogManager interopCatalogManager
        private readonly IUserContext userContext;

        public OrderService(IOrderRepository orderRepository,
            //IInteropCartManager interopCartManager,
            //IInteropCatalogManager interopCatalogManager,
            IUserContext userContext)
        {
            this.orderRepository = orderRepository;
            //this.interopCartManager = interopCartManager;
            //this.interopCatalogManager = interopCatalogManager;
            this.userContext = userContext;
        }

        public Task<Result<List<Entities.Order.Order>>> GetOrders()
        {
            return this.orderRepository.GetOrders(this.userContext.UserId);
        }

        public Task<Result> SubmitOrder(Entities.Order.Order order)
        {
            order.CustomerId = this.userContext.UserId;
            //return Result.Ok();
            //.And(() => this.interopCatalogManager.SubtractStock(order))
            //.And(() => this.orderRepository.SubmitOrder(order));
            //.And(() => this.interopCartManager.ClearCart(order.CustomerId));
            return new Task<Result>();
        }
    }
}
