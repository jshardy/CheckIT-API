using System;
using System.Threading.Tasks;
using CheckIT.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Data
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _context;
        public AddressRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Address> CreateAddress(Address address)
        {

            //save to database.
            await _context.Addresses.AddAsync(address); 
            await _context.SaveChangesAsync();

            return address;
        }

        public async Task<Address> GetAddress(int ID)
        {
            Address address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == ID);
            return address;
        }

    }
}