using AnyCompany.Data;
using AnyCompany.Service;
using AnyCompany.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AnyCompany.Tests
{
    [TestClass]
    public class OrderTest
    {
        private Mock<IOrderService> mockOrderService = new Mock<IOrderService>();
        [TestInitialize]
        public void SetupTests()
        {
            mockOrderService = new Mock<IOrderService>();
        }

        [TestMethod]
        public void TestPersonSave()
        {
            OrderController orderController = new OrderController(mockOrderService.Object);

            Order[] orders = 
            {
                new Order
                {
                    Amount = 20000,
                    Price = 20000,
                    ProductName = "iPhone 11",
                    Quantity = 1,
                    VAT = 0
                },
                new Order
                {
                     Amount = 16500,
                    Price = 16500,
                    ProductName = "Sumsung Galaxy S3",
                    Quantity = 1,
                    VAT = 0
                }
            };
            ActionResult result = orderController.SaveOrder("John", "123 ABC street", "1989-04-21", "RSA", orders);
        }
    }
}
