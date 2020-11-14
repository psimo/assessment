using AnyCompany.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Service.Repositories
{
    public static class CustomerRepository
    {
        private static string ConnectionString = @"Data Source=(local);Database=Customers;User Id=admin;Password=password;";
        public static Customer Load(Guid customerId)
        {
            Customer customer = new Customer();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(string.Format("SELECT * FROM Customer WHERE CustomerId = '{0}'", customerId),
                connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                customer.CustomerId = Guid.Parse(reader["CustomerId"].ToString());
                customer.Name = reader["Name"].ToString();
                customer.DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                customer.Country = reader["Country"].ToString();
                customer.Address = reader["Address"].ToString();
                customer.OrderDate = DateTime.Parse(reader["OrderDate"].ToString());
            }

            connection.Close();

            return customer;
        }

        public static List<Customer> LoadAll()
        {
            List<Customer> customers = new List<Customer>();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM Customer",
                connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Customer cust = new Customer();
                cust.CustomerId = Guid.Parse(reader["CustomerId"].ToString());
                cust.Name = reader["Name"].ToString();
                cust.DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                cust.Country = reader["Country"].ToString();
                cust.Address = reader["Address"].ToString();
                cust.OrderDate = DateTime.Parse(reader["OrderDate"].ToString());
                customers.Add(cust);
            }

            connection.Close();

            return customers;
        }
        public static bool Save(Customer customer)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Customer VALUES (@CustomerId, @Name, @Country, @DateOfBirth, @Address, @OrderDate)", connection);

            command.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
            command.Parameters.AddWithValue("@Name", customer.Name);
            command.Parameters.AddWithValue("@Country", customer.Country);
            command.Parameters.AddWithValue("@Address", customer.Address);
            command.Parameters.AddWithValue("@DateOfBirth", customer.DateOfBirth);
            command.Parameters.AddWithValue("@OrderDate", customer.OrderDate);

            command.ExecuteNonQuery();

            connection.Close();

            return true;
        }
    }
}
