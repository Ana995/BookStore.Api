using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Ports.Web.Order.Model.Response
{
   public class Order
    {
        public Guid Id { get; set; }
        public List<Item> Items { get; set; }
        public DateTime OrderDate { get; set; }
        public int Status { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
    }
}
