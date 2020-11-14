using AnyCompany.Data;
using AnyCompany.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AnyCompany.Web.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // GET: Order
        public ActionResult Index()
        {
           List<Customer> customers = _orderService.GetCustomerOrders();

            return View(customers);
        }
        public ActionResult SaveOrder(string name, String address, string dateofbirth, string country, Order[] order)
        {
                string result = "Error! Order Is Not Complete!";
            if (name != null && address != null && order != null)
            {
                var cutomerId = Guid.NewGuid();
                Customer customer = new Customer();
                customer.CustomerId = cutomerId;
                customer.Name = name;
                customer.Address = address;
                customer.Country = country;
                customer.DateOfBirth = Convert.ToDateTime(dateofbirth);
                customer.OrderDate = DateTime.Now;
                _orderService.SaveCustomer(customer);

                foreach (var item in order)
                {
                    var orderId = Guid.NewGuid();
                    Order O = new Order();
                    O.OrderId = orderId;
                    O.ProductName = item.ProductName;
                    O.Quantity = item.Quantity;
                    O.Price = item.Price;
                    O.Amount = item.Amount;
                    O.CustomerId = cutomerId;
                    _orderService.PlaceOrder(O, cutomerId);
                }


                result = "Success! Order Is Complete!";

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return RedirectToAction("Home", "Index");
        }



        public ActionResult EditOrder(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

           
            return View();

        }


        public ActionResult EditOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(order);
        }

        public ActionResult EditCustomer(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View();
        }
        public ActionResult EditCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(customer);
        }
    }
}