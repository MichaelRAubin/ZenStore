using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ZenStore.Models;
using ZenStore.Services;

namespace ZenStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsService _ps;
        private readonly ReviewsService _rs;

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(_ps.GetProducts());
        }
        [HttpGet("{id}")]

        public ActionResult<Product> Get(string id)
        {
            try
            {
                Product product = _ps.GetProductById(id);
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [HttpGet("{id}/reviews")]
        // public ActionResult<Review> GetReview(string id)
        // {
        //     try
        //     {
        //         List<Review> review = _rs.GetProductReviews(id);
        //         return Ok(review);
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product productData)
        {
            try
            {
                Product myProduct = _ps.AddProduct(productData);
                return Created("api/products/" + myProduct.Id, myProduct);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Product> Put(string id, [FromBody] Product productData)
        {
            try
            {
                productData.Id = id;
                var product = _ps.EditProduct(productData);
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(string id)
        {
            try
            {
                var product = _ps.DeleteProduct(id);
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        public ProductsController(ProductsService ps, ReviewsService rs)
        {
            _ps = ps;
            _rs = rs;
        }
    }

}
