using System;
using System.Collections.Generic;
using ZenStore.Interfaces;

namespace ZenStore.Models
{
    public class Order : IOrder
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public bool Canceled { get; set; }
        public bool Shipped { get; set; }
        public decimal Total { get; }
        public DateTime OrderIn { get; set; }
        public DateTime? OrderOut { get; set; }
        public DateTime? OrderCanceledAt { get; set; }

    }
}