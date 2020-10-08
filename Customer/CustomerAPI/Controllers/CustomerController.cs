using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet("get")]
        public IActionResult GetCustomers([FromQuery] string Id = null)
        {
            if (!String.IsNullOrEmpty(Id))
            {
                var customer = this.customerService.GetCustomerById(Id);
                if (customer != null)
                {
                    return Ok(customer);
                }
                return BadRequest(String.Format("{0}'ID Customer Record Not Found.!", Id));
            }
            else
            {
                var customer = this.customerService.Get();
                if (customer.Length > 0)
                {
                    return Ok(customer);
                }
                return BadRequest("Customers Not Found");
            }
        }

        [HttpPost("create")]
        public IActionResult AddCustomer(Customer customer)
        {
            var state = this.customerService.Create(customer);
            if (state == -99)
            {
                return BadRequest(String.Format("There is a record with id {0}", customer.Id));
            }
            if (state > 0)
            {
                return Ok("Created Customer Successful");
            }
            return BadRequest("Created Customer Unsuccessful");
        }

        [HttpPut("update")]
        public IActionResult UpdateCustomer(Customer customer)
        {

            var state = this.customerService.Update(customer);
            if (state)
            {
                return Ok(true);
            }
            return BadRequest(false);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteCustomerById(string id)
        {
            var state = this.customerService.Delete(id);
            if (state)
            {
                return Ok(true);
            }
            return BadRequest(false);
        }
    }
}
