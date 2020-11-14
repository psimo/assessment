using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Data
{
    public class Customer
    {
        public Customer()
        {
            Orders = new List<Order>();
        }
        public Guid CustomerId { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Order> Orders { get; set; }
    }
}
