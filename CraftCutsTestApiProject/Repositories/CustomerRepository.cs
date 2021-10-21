using CraftCutsTestApiProject.Context;
using CraftCutsTestApiProject.Contracts;
using CraftCutsTestApiProject.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _context;

        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> GetCustomers()
        {

            var query = "SELECT * FROM Customer";
            using (var connection = _context.CreateConnection())
            {
                var customers = await connection.QueryAsync<Customer>(query);
                return customers.ToList();
            }

        }
        public async Task<Customer> GetCustomer(int id)
        {
            var query = "SELECT * FROM Customer WHERE customer_id = @id";
            using(var connection = _context.CreateConnection())
            {
                var cust = await connection.QuerySingleOrDefaultAsync<Customer>(query,new { id });
                return cust;
            }
        }
        public async Task CreateCustomer(Customer customer)
        {
            var query = "INSERT INTO Customer (name,password,email,phone,birthday) VALUES (@name,@password,@email,@phone,@birthday)";
            var parameters = new DynamicParameters();
            parameters.Add("name", customer.name, DbType.String);
            parameters.Add("password", customer.password, DbType.String);
            parameters.Add("email", customer.email, DbType.String);
            parameters.Add("phone", customer.phone, DbType.String);
            parameters.Add("birthday", customer.birthday, DbType.DateTime);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task UpdateCustomer(int id, Customer customer)
        {
            var query = "UPDATE Customer SET name = @name, password = @password, email = @email, phone = @phone, birthday = @birthday WHERE customer_id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            parameters.Add("name", customer.name, DbType.String);
            parameters.Add("password", customer.password, DbType.String);
            parameters.Add("email", customer.email, DbType.String);
            parameters.Add("phone", customer.phone, DbType.String);
            parameters.Add("birthday", customer.birthday, DbType.DateTime);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task DeleteCustomer(int id)
        {
            var query = "DELETE FROM Customer WHERE customer_id = @id";
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<Customer> AuthorizationCustomer(string email,string password)
        {
            var query = "SELECT * FROM Customer WHERE password = @password AND email = @email";
            using(var connection = _context.CreateConnection())
            {
                var cust = await connection.QuerySingleOrDefaultAsync<Customer>(query, new {email , password}  );
                return cust;
            }
        }
        
    }
}
