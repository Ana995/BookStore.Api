﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.UserContext
{
    public interface IUserContext
    {
        Guid UserId { get; set; }
    }
}
