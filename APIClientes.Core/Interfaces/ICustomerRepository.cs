
using APIClientes.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClientes.Core.Interfaces
{
    public interface ICustomerRepository
    {
        public List<Customer> GetCustomers();

        public Customer GetCustomer(string cpf);

        public bool InsertCustomer(Customer customer);

        public bool DeleteCustomer(string cpf);

        public bool UpdateCustomer(string cpf, Customer customer);

        public string GetCpfByCustomer(Customer customer);

    }
}
