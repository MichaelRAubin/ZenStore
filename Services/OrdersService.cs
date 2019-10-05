using System;
using ZenStore.Data;
using ZenStore.Models;

namespace ZenStore.Services
{
    public class OrdersService
    {
        private readonly OrdersRepository _repo;

        public Order AddOrder(Order orderData)
        {
            orderData.Id = Guid.NewGuid().ToString();
            _repo.Create(orderData);
            return orderData;
        }

        //TODO Create method to edit order

        public Order ShipOrder(Order orderData)
        {
            var order = _repo.GetOrderById(orderData.Id);
            if (order == null || orderData.Shipped != false || orderData.Canceled != false) { throw new Exception("Order cannot be shipped"); }
            orderData.Shipped = true;
            orderData.OrderOut = DateTime.Now;

            bool success = _repo.SaveOrder(order);
            if (!success)
            {
                throw new Exception($"Unable to ship order.");

            }
            return order;
        }

        public Order CancelOrder(Order orderData)
        {
            var order = _repo.GetOrderById(orderData.Id);
            if (order == null || orderData.Shipped != false || orderData.Canceled != false) { throw new Exception("Order cannot be canceled"); }
            orderData.Canceled = true;
            orderData.OrderCanceledAt = DateTime.Now;

            bool success = _repo.SaveOrder(order);
            if (!success)
            {
                throw new Exception($"Unable to cancel order.");

            }
            return order;
        }

        public OrdersService(OrdersRepository repo)
        {
            _repo = repo;
        }
    }
}