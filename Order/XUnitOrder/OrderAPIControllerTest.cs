using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitOrder
{
    public class OrderAPIControllerTest
    {
        OrderController orderController;
        IOrderService orderService;

        public OrderAPIControllerTest()
        {
            orderService = new OrderManager(new EFOrder());
            orderController = new OrderController(orderService);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsBadRequest()
        {
            var result = orderController.GetOrders();
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Get_WhenCalledByUserId_ReturnsBadRequest()
        {
            var result = orderController.GetOrders("1");
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Get_WhenCalledByOrderId_ReturnsBadRequest()
        {
            var result = orderController.GetOrders(null, "1001");
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Add_WhenCalledBy_ReturnsOk()
        {
            var order = new Order
            {
                Id = "1001",
                CustomerId = "1",
                ImageUrl = "https://google.com",
                Price = 250,
                Quantity = 100,
                Status = "Active"
            };
            var result = orderController.AddOrder(order);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Add_WhenCalledBySameId_ReturnsOk()
        {
            var order = new Order
            {
                Id = "1001",
                CustomerId = "2",
                ImageUrl = "https://google.com",
                Price = 450,
                Quantity = 250,
                Status = "Active"
            };
            var result = orderController.AddOrder(order);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkRequest()
        {
            var result = orderController.GetOrders();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_WhenCalledByUserId_ReturnsOkRequest()
        {
            var result = orderController.GetOrders("1");
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_WhenCalledByOrderId_ReturnsOkRequest()
        {
            var result = orderController.GetOrders(null, "1001");
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Update_WhenCalled_ReturnsOkResult()
        {
            var order = new Order
            {
                Id = "1001",
                CustomerId = "2",
                ImageUrl = "https://google.com",
                Price = 450,
                Quantity = 250,
                Status = "False"
            };

            var result = orderController.UpdateOrder(order);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Update_WhenCalledByDifferentId_ReturnsBadResult()
        {
            var order = new Order
            {
                Id = "1002",
                CustomerId = "4",
                ImageUrl = "https://google.com",
                Price = 650,
                Quantity = 350,
                Status = "False"
            };

            var result = orderController.UpdateOrder(order);
            Assert.IsType<BadRequestObjectResult>(result);
        }


        [Fact]
        public void Delete_WhenCalledByOrderId_ReturnsOkResult()
        {
            var result = orderController.DeleteOrderById("1001");
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Delete_WhenCalledByOrderId_ReturnsBadResult()
        {
            var result = orderController.DeleteOrderById("1002");
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void ChangeStatus_WhenCalledByOrderId_ReturnsOkResult()
        {
            var result = orderController.ChangeStatusByOrderId("1001", "Passive");
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void ChangeStatus_WhenCalledByDifferentOrderId_ReturnsOkResult()
        {
            var result = orderController.ChangeStatusByOrderId("1002", "Passive");
            Assert.IsType<BadRequestObjectResult>(result);
        }

    }
}
