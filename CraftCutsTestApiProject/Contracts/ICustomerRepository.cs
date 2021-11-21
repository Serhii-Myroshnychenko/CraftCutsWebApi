using CraftCutsTestApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsTestApiProject.Contracts
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<Customer>> GetCustomers();
        public Task<Customer> GetCustomer(int id);
        public Task CreateCustomer(Customer customer);
        public Task UpdateCustomer(int id, Customer customer);
        public Task DeleteCustomer(int id);

        public Task<Customer> AuthorizationCustomer(AuthConstructor authConstructor);
        public Task<Customer> AuthorizationCustomerByParams(string email, string password);
        public Task Registration(string name,string email, string password, string phone, DateTime birthday);
        public Task<Customer> GetCustomerByParams(string name, string password, string email, string phone, DateTime birthday);

        public Task<Customer> IsItAnExistingMail(string email);
    }
}
