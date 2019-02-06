using System.Threading.Tasks;
using System.Collections.Generic;
using CheckIT.API.Models;

namespace CheckIT.API.Data
{
    public interface IAddressRepository
    {
        Task<Address> CreateAddress(Address address);
        Task<Address> GetAddress(int ID);
        Task<bool> DeleteAddress(int ID);
        Task<bool> ModifyAddress(int ID, Address address);
        Task<ICollection<Address>> GetAddressesByCountry(string country);
        Task<ICollection<Address>> GetAddressesByState(string state);
        Task<ICollection<Address>> GetAddressesByZip(string zip);
        Task<ICollection<Address>> GetAddressesByCity(string city);
        Task<ICollection<Address>> GetAddressesByStreet(string street);

    }
}