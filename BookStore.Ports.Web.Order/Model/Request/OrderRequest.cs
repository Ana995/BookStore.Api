using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Ports.Web.Order.Model.Request
{
    public class OrderRequest
    {
        public List<ProductItem> Products { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
    }
}
