using System;
using System.Collections.Generic;
using System.Linq;
using ZenStore.Data;
using ZenStore.Models;

namespace ZenStore.Services
{
    public class ProductsService
    {
        private readonly ProductsRepository _repo;


        public List<Product> GetProducts()
        {
            return _repo.GetAll().ToList();
        }

        public Product AddProduct(Product productData)
        {
            productData.Id = Guid.NewGuid().ToString();
            _repo.Create(productData);
            return productData;
        }

        public Product GetProductById(string id)
        {
            var product = _repo.GetProductById(id);
            if (product == null)
            {
                throw new Exception("Bad product ID");
            }
            return product;
        }

        public Product EditProduct(Product productData)
        {
            var product = GetProductById(productData.Id);
            product.Name = productData.Name;
            product.Description = productData.Description;
            product.Price = productData.Price;

            bool success = _repo.SaveProduct(product);
            if (!success)
            {
                throw new Exception("Could not edit product");
            }
            return product;
        }

        public Product DeleteProduct(string id)
        {
            var product = GetProductById(id);
            var deleted = _repo.DeleteProduct(id);

            if (!deleted)
            {
                throw new Exception($"Unable to remove product at Id {id}");
            }
            return product;
        }

        public ProductsService(ProductsRepository repo)
        {
            _repo = repo;

        }
    }
}



