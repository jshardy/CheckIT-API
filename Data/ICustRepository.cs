using System.Threading.Tasks;
using CheckIT.API.Models;

namespace CheckIT.API.Data
{
    public interface IAuthRepository
    {
        Task<Customer> CreateCustomer(User user, string password);
    }
}