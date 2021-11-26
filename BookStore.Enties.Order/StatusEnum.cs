using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Entities.Order
{
    public enum StatusEnum
    {
        NotSent = 1,
        InTransit = 2,
        Delivered = 3,
        Canceled = 4
    }
}
