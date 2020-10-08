using Business.Abstract;
using Business.Concrete;
using CustomerAPI.Controllers;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace xUnitCustomer
{
    public class CustomerAPIControllerTest
    {
        CustomerController customerController;
        ICustomerService customerService;

        public CustomerAPIControllerTest()
        {
            customerService = new CustomerManager(new EfCustomer());
            customerController = new CustomerController(customerService);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsBadResult()
        {
            var result = customerController.GetCustomers();
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Get_WhenCalledByUserId_ReturnsBadResult()
        {
            var result = customerController.GetCustomers("1");
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Add_WhenCalled_ReturnsOk()
        {
            var customer = new Customer
            {
                Id = "1",
                Name = "Onur",
                Email = "onurekkazan@gmail.com"
            };

            var result = customerController.AddCustomer(customer);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var result = customerController.GetCustomers();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_WhenCalledByUserId_ReturnsOkResult()
        {
            var result = customerController.GetCustomers("1");
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Add_WhenCalledBySameId_ReturnsBadResult()
        {
            var customer = new Customer
            {
                Id = "1",
                Name = "Onur Ek.",
                Email = "onurekkazan@outlook.com"
            };

            var result = customerController.AddCustomer(customer);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Update_WhenCalled_ReturnsOkResult()
        {
            var customer = new Customer
            {
                Id = "1",
                Name = "Onur Ek.",
                Email = "onurekkazan@outlook.com"
            };

            var result = customerController.UpdateCustomer(customer);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Update_WhenCalledByDifferentId_ReturnsBadResult()
        {
            var customer = new Customer
            {
                Id = "2",
                Name = "Onur Ek.",
                Email = "onurekkazan@outlook.com"
            };

            var result = customerController.UpdateCustomer(customer);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Delete_WhenCalledByCustomerId_ReturnsOkResult()
        {
            var result = customerController.DeleteCustomerById("1");
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Delete_WhenCalledByCustomerId_ReturnsBadResult()
        {
            var result = customerController.DeleteCustomerById("2");
            Assert.IsType<BadRequestObjectResult>(result);
        }

    }
}
