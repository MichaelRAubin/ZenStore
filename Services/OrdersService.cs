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
            orderData.OrderIn = DateTime.Now;
            _repo.Create(orderData);
            return orderData;
        }

        public Order EditOrder(Order orderData)
        {
            var order = _repo.GetOrderById(orderData.Id);
            if (order.Shipped == true)
            { throw new Exception("Order has been shipped - cannot be edited"); }
            if (order.Canceled == true)
            { throw new Exception("Order has been canceled - cannot be edited"); }
            order.Name = orderData.Name;
            order.Products = orderData.Products;
            orderData.Products.ForEach(item =>
            {
                _repo.CreateOrderItem(orderData.Id, item.Id);
            });
            order.Products = _repo.getOrderProducts(order.Id);
            return order;

        }

        public List<Order> GetOrders()
        {
            return _repo.GetAllOrders().ToList();
        }


        public Order ShipOrder(string id)
        {
            var order = _repo.GetOrderById(id);
            if (order.Shipped == true)
            { throw new Exception("Order has already been shipped"); }
            if (order.Canceled == true)
            { throw new Exception("Order has been canceled - cannot be shipped"); }
            order.OrderOut = DateTime.Now;
            order.Shipped = true;
            _repo.SaveOrder(order);
            order.Products = _repo.getOrderProducts(order.Id);

            return order;
        }

        public Order CancelOrder(string id)
        {
            var order = _repo.GetOrderById(id);
            if (order.Shipped == true)
            { throw new Exception("Order has already been shipped"); }
            if (order.Canceled == true)
            { throw new Exception("Order has already been canceled"); }
            order.OrderCanceledAt = DateTime.Now;
            order.Canceled = true;
            _repo.SaveOrder(order);
            order.Products = _repo.getOrderProducts(order.Id);

            return order;
        }

        public OrdersService(OrdersRepository repo)
        {
            _repo = repo;
        }
    }
}