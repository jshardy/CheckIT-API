using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using CheckIT.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Data
{
    public class AddressRepository
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

        public async Task<bool> DeleteAddress(int ID)
        {
            Address address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == ID);

            if (address == null)
                return false;
            else
            {
                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> ModifyAddress(int ID, Address change)
        {
            Address exist = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == ID);

            if (exist == null)
                return false;

            _context.Addresses.Remove(exist);

            if (change.Country != null)
                exist.Country = change.Country;
            if (change.State != null)
                exist.State = change.State;
            if (change.ZipCode != null)
                exist.ZipCode = change.ZipCode;
            if (change.Street != null)
                exist.Street = change.Street;
            if (change.AptNum != null)
                exist.AptNum = change.AptNum;

            await _context.Addresses.AddAsync(exist);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ICollection<Address>> GetAddressesByCountry(string country)
        {
            ICollection<Address> addresses = await _context.Addresses.Where(x => x.Country == country).ToListAsync();
            return addresses;
        }
        public async Task<ICollection<Address>> GetAddressesByState(string state)
        {
            ICollection<Address> addresses = await _context.Addresses.Where(x => x.State == state).ToListAsync();
            return addresses;
        }
        public async Task<ICollection<Address>> GetAddressesByZip(string zip)
        {
            ICollection<Address> addresses = await _context.Addresses.Where(x => x.ZipCode == zip).ToListAsync();
            return addresses;
        }
        public async Task<ICollection<Address>> GetAddressesByCity(string city)
        {
            ICollection<Address> addresses = await _context.Addresses.Where(x => x.City == city).ToListAsync();
            return addresses;
        }
        public async Task<ICollection<Address>> GetAddressesByStreet(string street)
        {
            ICollection<Address> addresses = await _context.Addresses.Where(x => x.Street == street).ToListAsync();
            return addresses;
        }

    }
}