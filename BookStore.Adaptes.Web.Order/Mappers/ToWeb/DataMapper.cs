using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model = BookStore.Ports.Web.Order.Model.Response;
using Entity = BookStore.Entities.Order;

namespace BookStore.Adaptes.Web.Order.Mappers.ToWeb
{
  public static  class DataMapper
    {
        public static List<Model.Order> ToWeb(this List<Entity.Order> orders)
        {
            return orders.Select(o => o.ToWeb()).ToList();
        }

        public static Model.Order ToWeb(this Entity.Order order)
        {
            return new Model.Order
            {
                Id = order.Id,
                Status = (int)order.Status,
                OrderDate = order.OrderDateUtc,
                City = order.City,
                StreetName = order.StreetName,
                StreetNumber = order.StreetNumber,
                Items = order.Items.ToWeb()
            };
        }

        public static List<Model.Item> ToWeb(this List<Entity.Item> items)
        {
            return items.Select(o => o.ToWeb()).ToList();
        }

        public static Model.Item ToWeb(this Entity.Item item)
        {
            return new Model.Item
            {
                Id = item.Id,
                ProductId = item.ProductId,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity
            };
        }
    }
}
