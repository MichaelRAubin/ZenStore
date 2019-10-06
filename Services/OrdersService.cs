using System;
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
            if (order.Shipped)
            { throw new Exception("Order has been shipped - cannot be edited"); }
            if (order.Canceled)
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
        internal Order ShipOrder(string id)
        {
            var order = _repo.GetOrderById(id);
            if (order.Canceled)
            {
                throw new Exception("Order cannot be shipped after canceled");
            }
            if (order.OrderOut != null)
            {
                throw new Exception("Order Already Shipped");
            }
            order.OrderOut = DateTime.Now;
            order.Shipped = true;
            _repo.SaveOrder(order);
            return order;
        }

        internal Order CancelOrder(string id)
        {
            var order = _repo.GetOrderById(id);
            if (order.Shipped)
            {
                throw new Exception("Order cannot be canceled after shipped");
            }
            if (order.OrderCanceledAt != null)
            {
                throw new Exception("Order Already Canceled");
            }
            order.OrderCanceledAt = DateTime.Now;
            order.Canceled = true;
            _repo.SaveOrder(order);
            return order;
        }


        public OrdersService(OrdersRepository repo)
        {
            _repo = repo;
        }
    }
}