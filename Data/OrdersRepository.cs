using System;
using System.Collections.Generic;
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
            return _db.QueryFirstOrDefault<Order>(@"
            SELECT * FROM orders 
               WHERE id = @id",
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

        public IEnumerable<Order> GetAllOrders()
        {
            return _db.Query<Order>(@"SELECT * FROM orders o
            JOIN order_items oi ON o.id = oi.orderid
            JOIN products p ON p.id = oi.itemid
            WHERE o.id = @id"
            );
        }
        internal List<Product> getOrderProducts(string orderId)
        {
            var sql = @"SELECT * FROM order_items oi
            JOIN products p ON p.id = oi.itemid
            WHERE oi.orderid = @orderId";
            return _db.Query<Product>(sql, new { orderId }).AsList();
        }

        public OrdersRepository(IDbConnection db)
        {
            _db = db;
        }

    }
}