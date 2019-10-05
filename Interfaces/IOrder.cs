using System;
using System.Collections.Generic;
using System.Linq;
using ZenStore.Models;

namespace ZenStore.Interfaces
{
    public interface IOrder
    {
        string Id { get; set; }
        string Name { get; set; }
        List<Product> Products { get; set; }
        bool Canceled { get; set; }
        bool Shipped { get; set; }
        //decimal Total { get { return Products.Sum(p => p.Price); } }
        DateTime OrderIn { get; set; }
        DateTime? OrderOut { get; set; }
        DateTime? OrderCanceledAt { get; set; }
    }
}