using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService order_Service;

        public OrderController(IOrderService order_Service)
        {
            this.order_Service = order_Service;
        }

        [HttpPost("create")]
        public IActionResult AddOrder(Order order)
        {
            var state = this.order_Service.Create(order);
            if (state == -99)
            {
                return BadRequest(String.Format("There is a record with id {0}", order.Id));
            }
            if (state > 0)
            {
                return Ok("Created Order Successful");
            }
            return BadRequest("Created Order Unseccessful");
        }

        [HttpPut("update")]
        public IActionResult UpdateOrder(Order order)
        {
            var state = this.order_Service.Update(order);
            if (state)
            {
                return Ok(true);
            }
            return BadRequest(false);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteOrderById(string id)
        {
            var state = this.order_Service.Delete(id);
            if (state)
            {
                return Ok(true);
            }
            return BadRequest(false);
        }

        [HttpGet, Route("get")]
        public IActionResult GetOrders([FromQuery] string userId = null, [FromQuery] string orderId = null)
        {
            if (!String.IsNullOrEmpty(userId))
            {
                var orders = this.order_Service.GetOrderByUserId(userId);
                if (orders.Length > 0)
                {
                    return Ok(orders);
                }
                return BadRequest(String.Format("{0} User Id Order Not Found", userId));
            }
            else if (!String.IsNullOrEmpty(orderId))
            {
                var orders = this.order_Service.GetOrderByOrderId(orderId);
                if (orders != null)
                {
                    return Ok(orders);
                }
                return BadRequest(String.Format("{0}' ID Order Record Not Found.!", orderId));
            }
            else
            {
                var orders = this.order_Service.Get();
                if (orders.Length > 0)
                {
                    return Ok(orders);
                }
                return BadRequest("Order Not Found");
            }
        }

        [HttpPut("changeStatus")]
        public IActionResult ChangeStatusByOrderId(string orderId, string newStatus)
        {
            var result = this.order_Service.ChangeStatus(orderId, newStatus);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
