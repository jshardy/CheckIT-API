using System.Threading.Tasks;
using System.Collections.Generic;
using CheckIT.API.Models;

namespace CheckIT.API.Data
{
    public interface ICustRepository
    {
        Task<Customer> CreateCustomer(Customer customer, int addressID);
        Task<Customer> GetCustomer(int ID);
        Task<bool> DeleteCustomer(int ID);
        Task<bool> ModifyCustomer(int ID, Customer customer, int newAddress);
        Task<ICollection<Customer>> GetCustomersByFirstName(string firstName);
        Task<ICollection<Customer>> GetCustomersByLastName(string lastName);
        Task<ICollection<Customer>> GetCustomersByCompanyName(string companyName);
        Task<ICollection<Customer>> GetCustomersByAddress(Address address);
        Task<ICollection<Customer>> GetCustomersByPhoneNumber(string phone);
        Task<ICollection<Customer>> GetCustomersByEmail(string email);

    }
}