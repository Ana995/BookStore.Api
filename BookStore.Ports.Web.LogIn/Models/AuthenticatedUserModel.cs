﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Ports.Web.LogIn.Models
{
   public class AuthenticatedUserModel
    {
        public string Access_Token { get; set; }
        public string UserName { get; set; }
    }
}
