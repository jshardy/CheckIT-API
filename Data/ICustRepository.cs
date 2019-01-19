using System.Threading.Tasks;
using CheckIT.API.Models;

namespace CheckIT.API.Data
{
    public interface ICustRepository
    {
        Task<Customer> CreateCustomer(Customer customer);
    }
}