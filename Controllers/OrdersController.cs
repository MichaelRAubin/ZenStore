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

        [HttpPut("{id}")]
        public ActionResult<Order> Put(Order orderData)
        {
            try
            {
                Order myOrder = _os.EditOrder(orderData);
                return Ok(orderData);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}/ship")]
        public ActionResult<Order> Put(string id)
        {
            try
            {
                var order = _os.ShipOrder(id);
                return Ok(order);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}/cancel")]
        public ActionResult<Order> PutCancel(string id)
        {
            try
            {
                var order = _os.CancelOrder(id);
                return Ok(order);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public OrdersController(OrdersService os)
        {
            _os = os;
        }
    }

}
