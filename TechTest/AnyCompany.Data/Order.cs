using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Data
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public double VAT { get; set; }
        public Guid CustomerId { get; set; }
    }
}
