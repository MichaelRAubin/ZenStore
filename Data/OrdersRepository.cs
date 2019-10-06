using System;
using System.Data;
using Dapper;
using ZenStore.Models;

namespace ZenStore.Data
{
    public class OrdersRepository
    {
        private readonly IDbConnection _db;

        public Order Create(Order orderData)
        {
            var sql = @"INSERT INTO orders
            (id, name, orderin)
            VALUES
            (@Id, @Name, @OrderIn);";
            var x = _db.Execute(sql, orderData);

            return orderData;
        }

        internal bool SaveOrder(Order Order)
        {
            var nRows = _db.Execute(@"
            UPDATE orders SET
            name = @Name,
            canceled = @Canceled,
            shipped = @Shipped,
            orderout = @OrderOut,
            ordercanceledat = @OrderCanceledAt
            WHERE id = @Id
            ", Order);
            return nRows == 1;
        }

        public Order GetOrderById(string id)
        {
            return _db.QueryFirstOrDefault<Order>(
              "SELECT * FROM orders WHERE id = @id",
                new { id }
            );
        }

        internal bool CreateOrderItem(string orderId, string itemId)
        {
            var id = Guid.NewGuid().ToString();
            var sql = @"INSERT INTO order_items (id, itemid, orderid)
            VALUES (@id, @itemId, @orderId);";
            var x = _db.Execute(sql, new { id, orderId, itemId });
            return x == 1;
        }

        public OrdersRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}