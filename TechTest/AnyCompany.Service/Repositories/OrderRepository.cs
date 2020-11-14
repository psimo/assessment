using AnyCompany.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Service.Repositories
{
    internal class OrderRepository
    {
        private static string ConnectionString = @"Data Source=(local);Database=Customers;User Id=admin;Password=password;";

        public void Save(Order order)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Orders VALUES (@OrderId,@ProductName,@Quantity,@VAT, @Price,  @Amount, @CustomerId)", connection);

            command.Parameters.AddWithValue("@OrderId", order.OrderId);
            command.Parameters.AddWithValue("@ProductName", order.ProductName);
            command.Parameters.AddWithValue("@Quantity", order.Quantity);
            command.Parameters.AddWithValue("@VAT", order.VAT);
            command.Parameters.AddWithValue("@Price", order.Price);
            command.Parameters.AddWithValue("@Amount", order.Amount);
            command.Parameters.AddWithValue("@CustomerId", order.CustomerId);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public List<Order> GetOrdersByCustomerId(Guid customerId)
        {
            List<Order> orders = new List<Order>();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(String.Format("SELECT * FROM Orders where CustomerId = '{0}'", customerId),
                connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Order o = new Order();
                o.CustomerId = Guid.Parse(reader["CustomerId"].ToString());
                o.ProductName = reader["ProductName"].ToString();
                o.Amount = Decimal.Parse(reader["Amount"].ToString());
                o.OrderId = Guid.Parse(reader["OrderId"].ToString());
                o.Price = Decimal.Parse(reader["Price"].ToString());
                o.Quantity = int.Parse(reader["Quantity"].ToString());
                o.VAT = double.Parse(reader["VAT"].ToString());
                orders.Add(o);
            }

            connection.Close();

            return orders;
        }
    }
}
