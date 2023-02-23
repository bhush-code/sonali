using System;
using System.Collections.Generic;

namespace OrderManagement.Models
{
    public partial class Product
    {
        public Product()
        {
            Cart = new HashSet<Cart>();
            OrderItems = new HashSet<OrderItems>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public int? Quantity { get; set; }
        public string Image { get; set; }
        public int? Status { get; set; }

        public ICollection<Cart> Cart { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
