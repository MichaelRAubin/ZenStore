using System.Collections.Generic;
using System.Data;
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
            return productData;
        }

        public Product GetProductById(string id)
        {
            return;
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