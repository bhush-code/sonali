using System;
using System.Collections.Generic;

namespace OrderManagement.Models
{
    public partial class Users
    {
        public Users()
        {
            Cart = new HashSet<Cart>();
            Orders = new HashSet<Orders>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public int? Status { get; set; }

        public ICollection<Cart> Cart { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
