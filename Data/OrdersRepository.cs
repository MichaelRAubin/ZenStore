using System.Data;
using ZenStore.Models;

namespace ZenStore.Data
{
    public class OrdersRepository
    {
        private readonly IDbConnection _db;

        public Order Create(Order orderData)
        {
            return orderData;
        }

        public Product EditOrderById(string id)
        {
            return;
        }

        public Order ShipOrderById(string id)//needs to be a bool
        {
            return;
        }

        public Order CancelOrderById(string id)//needs to be a bool
        {
            return
        }

        //TODO may need to add a save feature
        //Need to add cancel and shipped bool properties

        public OrdersRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}