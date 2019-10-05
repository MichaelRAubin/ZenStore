using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ZenStore.Models;
using ZenStore.Services;

namespace ZenStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ReviewsService _rs;

        // [HttpGet]
        // public ActionResult<IEnumerable<Product>> Get()
        // {
        //     return Ok(_ps.GetProducts());
        // }
        // [HttpGet("{id}")]

        // public ActionResult<Product> Get(string id)
        // {
        //     try
        //     {
        //         Product product = _ps.GetProductById(id);
        //         return Ok(product);
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

        [HttpPost]
        public ActionResult<Review> Post([FromBody] Review reviewData)
        {
            try
            {
                Review myReview = _rs.AddReview(reviewData);
                return Created("api/products/" + myReview.Id, myReview);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Review> Put(string id, [FromBody] Review reviewData)
        {
            try
            {
                reviewData.Id = id;
                var review = _rs.EditReview(reviewData);
                return Ok(review);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [HttpDelete("{id}")]
        // public ActionResult<Product> Delete(string id)
        // {
        //     try
        //     {
        //         var product = _ps.DeleteProduct(id);
        //         return Ok(product);
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }



        public ReviewsController(ReviewsService rs)
        {
            _rs = rs;
        }
    }

}
