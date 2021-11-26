using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BookStore.Entities.Order;
using BookStore.Infrastructure;
using BookStore.Infrastructure.Configuration.Interfaces;
using BookStore.Ports.DataAccess.Order.DataAccess;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BookStore.Adapters.DataAccess.Order.DataAccess
{
    public class OrderRepository: IOrderRepository
    {
        private IBookStoreConfiguration bookStoreConfiguration { get; set; }

        public OrderRepository(IBookStoreConfiguration bookStoreConfiguration)
        {
            this.bookStoreConfiguration = bookStoreConfiguration;
        }

        public async Task<Result<List<Entities.Order.Order>>> GetOrders(Guid userId)
        {
            const string sql = @"SELECT    o.[Id]
                                          ,o.[CustomerId]
                                          ,o.[OrderDateUtc]
                                          ,o.[Status]
                                          ,o.[StreetName]
                                          ,o.[StreetNumber]
                                          ,o.[City]
	                                      ,i.[Id]
                                          ,i.[ProductId]
                                          ,i.[Name]
                                          ,i.[Price]
                                          ,i.[Quantity]
                                      FROM [order].[Order] o
                                      INNER JOIN [order].[Item] i on i.[OrderId] = o.[Id]
                                      WHERE [CustomerId] = @CustomerId";
            try
            {
                using (var db = new SqlConnection(this.bookStoreConfiguration.ConnectionString))
                {
                    OpenConnection(db);
                   var ordersDictionary = new Dictionary<Guid, Entities.Order.Order>();
                   await db.QueryAsync<Entities.Order.Order, Item, Entities.Order.Order>(sql, (order, item) =>
                       {
                           if (!ordersDictionary.ContainsKey(order.Id))
                           {
                               ordersDictionary.Add(order.Id, order);
                           }

                           var currentOrder = ordersDictionary[order.Id];
                           if (!currentOrder.Items.Exists(m => m.Id == item.Id))
                           {
                               currentOrder.Items.Add(item);
                           }

                           return order;
                       },
                       new {CustomerId = userId}
                   );
                   return Result.Ok(ordersDictionary.Values.ToList());
                }
            }
            catch (Exception e)
            {
                return Result.Error<List<Entities.Order.Order>>(HttpStatusCode.InternalServerError, "Repo error!");
            }
        }

        public Task<Result> SubmitOrder(Entities.Order.Order order)
        {
            throw new NotImplementedException();
        }

        private static void OpenConnection(IDbConnection db)
        {
            if (db.State != ConnectionState.Open)
            {
                db.Open();
            }
        }
    }
}
