using System.Threading.Tasks;
using CheckIT.API.Models;

namespace CheckIT.API.Data
{
    public interface IAddressRepository
    {
        Task<Address> CreateAddress(Address address);
        Task<Address> GetAddress(int ID);
        Task<bool> DeleteAddress(int ID);
        Task<bool> ModifyAddress(int ID, Address address);

    }
}