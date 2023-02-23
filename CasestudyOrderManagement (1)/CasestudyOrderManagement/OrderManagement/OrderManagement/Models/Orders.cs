using System;
using System.Collections.Generic;

namespace OrderManagement.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public string OrderNo { get; set; }
        public decimal? OrderTotal { get; set; }
        public string OrderStatus { get; set; }

        public Users User { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
