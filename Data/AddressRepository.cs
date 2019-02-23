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
            Address address = await _context.Addresses.Include(p => p.AddressCust)
                                                      .FirstOrDefaultAsync(x => x.Id == ID);
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

        public async Task<IEnumerable<Address>> GetAddresses(string country, 
                                                            string state,
                                                            string zip,
                                                            string city,
                                                            string street,
                                                            int CustomerAddID)
        {


            IQueryable<Address> query = _context.Addresses;

            if(country != null)
            {
                query = query.Where(x => x.Country == country);
            }

            if(state != null)
            {
                query = query.Where(x => x.State == state);
            }

            if(zip != null)
            {
                query = query.Where(x => x.ZipCode == zip);
            }

            if(city != null)
            {
                query = query.Where(x => x.City == city);
            }

            if(street != null)
            {
                query = query.Where(x => x.Street == street);
            }

            if(CustomerAddID != -1)
            {
                query = query.Where(x => x.AddressCust.Id == CustomerAddID);
            }

            return await query.ToListAsync();
        }
    }
}