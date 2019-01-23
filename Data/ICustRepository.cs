using System.Threading.Tasks;
using CheckIT.API.Models;

namespace CheckIT.API.Data
{
    public interface ICustRepository
    {
        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer> GetCustomer(int ID);
        Task<bool> DeleteCustomer(int ID);
        Task<bool> ModifyCustomer(int ID, Customer customer);

    }
}