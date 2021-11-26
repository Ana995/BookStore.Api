using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Infrastructure;
using BookStore.Ports.Web.Order.Interfaces;
using BookStore.Ports.Web.Order.Model.Request;
using BookStore.Ports.Web.Order.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Server.Controllers
{
    public class OrderController: Controller
    {

        private readonly IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager)
        {
            this._orderManager = orderManager;
        }

        // GET api/v1/order
        [HttpGet]
        public Task<Result<List<Order>>> Get()
        {
            return this._orderManager.GetOrders();
        }

        // POST api/v1/order
        [HttpPost]
        public Task<Result> Post([FromBody] OrderRequest order)
        {
            return this._orderManager.SubmitOrder(order);
        }

    }
}
