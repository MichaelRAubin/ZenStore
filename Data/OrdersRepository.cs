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
            orderout = @OrderOut,
            canceled = @Canceled,
            shipped = @Shipped,
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


        public OrdersRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}