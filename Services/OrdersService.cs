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




        public OrdersService(OrdersRepository repo)
        {
            _repo = repo;
        }
    }
}