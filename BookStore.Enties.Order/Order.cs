using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Entities.Order;

namespace BookStore.Entities.Order
{
   public  class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public DateTime OrderDateUtc { get; set; }
        public StatusEnum Status { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
    }
}
