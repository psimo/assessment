using AnyCompany.Data;
using AnyCompany.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Service
{
    public class OrderService : IOrderService
    {
        private readonly OrderRepository orderRepository = new OrderRepository();

        public bool PlaceOrder(Order order, Guid customerId)
        {
            Customer customer = CustomerRepository.Load(customerId);

            if (order.Amount == 0)
                return false;

            if (customer.Country == "UK")
                order.VAT = 0.2d;
            else
                order.VAT = 0;

            order.CustomerId = customerId;

            orderRepository.Save(order);

            return true;
        }

        public List<Customer> GetCustomers()
        {
            return CustomerRepository.LoadAll();
        }

        public List<Customer> GetCustomerOrders()
        {
            List<Customer> customerOrderList = new List<Customer>();

            List<Customer> customers = CustomerRepository.LoadAll();
            foreach(var customer in customers)
            {
                var orders = orderRepository.GetOrdersByCustomerId(customer.CustomerId);
                customer.Orders.AddRange(orders);
                customerOrderList.Add(customer);
            }

            return customerOrderList;
        }

        public bool SaveCustomer(Customer customer)
        {
           return CustomerRepository.Save(customer);
        }
    }
}
