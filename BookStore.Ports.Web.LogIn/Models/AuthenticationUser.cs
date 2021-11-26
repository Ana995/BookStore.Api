using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Ports.Web.LogIn.Models
{
    public class AuthenticationUser
    {
        [Required(ErrorMessage = "Email Address is required")]
        public string Email  { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
