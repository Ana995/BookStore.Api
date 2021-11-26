using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.UserContext
{
   public class UserContext: IUserContext
    {
        public Guid UserId { get; set; }

        public UserContext(Guid userId)
        {
            UserId = userId;
        }
    }
}
