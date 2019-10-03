using System.Collections.Generic;
using System.Data;
using Dapper;
using ZenStore.Models;

namespace ZenStore.Data
{
    public class ProductsRepository
    {
        private readonly IDbConnection _db;

        public IEnumerable<Product> GetAll()
        {
            return;
        }

        public Product Create(Product productData)
        {
            var sql = @"INSERT INTO products
            (id, name, description, price)
            VALUES
            (@Id, @Name, @Description, @Price);";
            var x = _db.Execute(sql, productData);
            return productData;
        }

        public Product GetProductById(string id)
        {
            return _db.QueryFirstOrDefault<Product>(
              "SELECT * FROM products WHERE id = @id",
                new { id }
            );
        }

        public Product EditProductById(string id)
        {

            return;
        }

        internal bool DeleteProduct(string id)
        {
            return;
        }

        public ProductsRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}