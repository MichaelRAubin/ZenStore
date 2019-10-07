using System;
using System.Collections.Generic;
using System.Linq;
using ZenStore.Data;
using ZenStore.Models;

namespace ZenStore.Services
{
    public class OrdersService
    {
        private readonly OrdersRepository _repo;

        internal Order AddOrder(Order orderData)
        {
            orderData.Id = Guid.NewGuid().ToString();
            _repo.Create(orderData);
            return orderData;
        }

        internal Order EditOrder(Order orderData)
        {
            var order = _repo.GetOrderById(orderData.Id);
            if (order.Shipped == true)
            { throw new Exception("Order has been shipped - cannot be edited"); }
            if (order.Canceled == true)
            { throw new Exception("Order has been canceled - cannot be edited"); }
            orderData.Id = Guid.NewGuid().ToString();
            orderData.OrderIn = DateTime.Now;
            _repo.Create(orderData);
            orderData.Products.ForEach(item =>
            {
                _repo.CreateOrderItem(orderData.Id, item.Id);
            });
            return orderData;

        }

        public List<Order> GetOrders()
        {
            return _repo.GetAllOrders().ToList();
        }


        internal Order ShipOrder(Order orderData)
        {
            var order = _repo.GetAllOrders().Where(o => o.OrderOut == null && !o.Canceled && !o.Shipped).ToList();
            orderData.OrderOut = DateTime.Now;
            orderData.Shipped = true;
            _repo.SaveOrder(orderData);
            return orderData;
        }

        internal Order CancelOrder(Order orderData)
        {
            var order = _repo.GetAllOrders().Where(o => o.OrderOut == null && !o.Canceled && !o.Shipped).ToList();
            orderData.OrderCanceledAt = DateTime.Now;
            orderData.Canceled = true;
            _repo.SaveOrder(orderData);
            return orderData;
        }

        public OrdersService(OrdersRepository repo)
        {
            _repo = repo;
        }
    }
}