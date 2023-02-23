using System;
using System.Collections.Generic;

namespace OrderManagement.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalPrice { get; set; }

        public Product Product { get; set; }
        public Users User { get; set; }
    }
}
