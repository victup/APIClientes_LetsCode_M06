using APIClientes.Core.Interfaces;
using APIClientes.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClientes.Core.Services
{
    public class CustomerService: ICustomerService
    {

        public ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository=customerRepository;
        }

        public bool DeleteCustomer(string cpf)
        {
            return _customerRepository.DeleteCustomer(cpf);
        }

        public Customer GetCustomer(string cpf)
        {
            return _customerRepository.GetCustomer(cpf);
        }

        public List<Customer> GetCustomers()
        {
            return _customerRepository.GetCustomers();
        }

        public bool InsertCustomer(Customer customer)
        {
            return _customerRepository.InsertCustomer(customer);
        }

        public bool UpdateCustomer(string cpf, Customer customer)
        {
            return _customerRepository.UpdateCustomer(cpf, customer);
        }
    }
}
