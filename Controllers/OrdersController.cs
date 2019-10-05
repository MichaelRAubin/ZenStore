using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ZenStore.Models;
using ZenStore.Services;

namespace ZenStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersService _os;

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
        public ActionResult<Order> Post([FromBody] Order orderData)
        {
            try
            {
                Order myOrder = _os.AddOrder(orderData);
                return Created("api/orders/" + myOrder.Id, myOrder);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [HttpPut("{id}")]
        // public ActionResult<Product> Put(string id, [FromBody] Product productData)
        // {
        //     try
        //     {
        //         productData.Id = id;
        //         var product = _ps.EditProduct(productData);
        //         return Ok(product);
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

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



        public OrdersController(OrdersService os)
        {
            _os = os;

        }
    }

}
