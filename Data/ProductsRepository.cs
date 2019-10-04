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
            return _db.Query<Product>("SELECT * FROM products");
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

        internal bool SaveProduct(Product product)
        {
            var nRows = _db.Execute(@"
                UPDATE products SET
                name = @Name,
                description = @Description,
                price = @Price
                WHERE id = @Id
                ", product);
            return nRows == 1;
        }

        internal bool DeleteProduct(string id)
        {
            var success = _db.Execute("DELETE FROM products WHERE id = @id", new { id });
            if (success == 1)
            {
                return true;
            }
            return false;
        }

        public ProductsRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}