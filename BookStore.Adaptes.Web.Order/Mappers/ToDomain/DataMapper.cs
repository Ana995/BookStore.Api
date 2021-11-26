using System.Collections.Generic;
using System.Linq;
using Model = BookStore.Ports.Web.Order.Model.Request;
using Entity = BookStore.Entities.Order;

namespace BookStore.Adaptes.Web.Order.Mappers.ToDomain
{
   public static class DataMapper
    {
        public static Entity.Order ToDomain(this Model.OrderRequest order)
        {
            return new Entity.Order
            {
                City = order.City,
                StreetName = order.StreetName,
                StreetNumber = order.StreetNumber,
                Items = order.Products.ToDomain()
            };
        }

        public static List<Entity.Item> ToDomain(this List<Model.ProductItem> items)
        {
            return items.Select(o => o.ToDomain()).ToList();
        }

        public static Entity.Item ToDomain(this Model.ProductItem productItem)
        {
            return new Entity.Item
            {
                ProductId = productItem.Id,
                Name = productItem.Name,
                Price = productItem.Price,
                Quantity = productItem.Quantity
            };
        }

    }
}
