using AnyCompany.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Service
{
    public interface IOrderService
    {
        bool PlaceOrder(Order order, Guid customerId);
        List<Customer> GetCustomers();

        List<Customer> GetCustomerOrders();

        bool SaveCustomer(Customer c);
    }
}
