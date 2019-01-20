using System.Threading.Tasks;
using CheckIT.API.Models;

namespace CheckIT.API.Data
{
    public interface IAddressRepository
    {
        Task<Address> CreateAddress(Address address);
        Task<Address> GetAddress(int ID);

    }
}