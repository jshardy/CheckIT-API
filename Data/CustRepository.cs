using System;
using System.Threading.Tasks;
using CheckIT.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Data
{
    public class CustRepository : ICustRepository
    {
        private readonly DataContext _context;
        private AddressRepository _AddRepo;
        public CustRepository(DataContext context)
        {
            _context = context;
            _AddRepo = new AddressRepository(context);
        }
        public async Task<Customer> CreateCustomer(Customer customer, int AddressId)
        {

            //save to database.

            customer.Address = await _AddRepo.GetAddress(AddressId);

            await _context.Customers.AddAsync(customer); 
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> GetCustomer(int ID)
        {
            Customer cust = await _context.Customers.FirstOrDefaultAsync(x => x.ID == ID);
            return cust;
        }

        public async Task<bool> DeleteCustomer(int ID)
        {
            Customer cust = await _context.Customers.FirstOrDefaultAsync(x => x.ID == ID);

            if (cust == null)
                return false;
            else
            {
                _context.Customers.Remove(cust);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> ModifyCustomer(int ID, Customer change, int newAddress)
        {
            Customer exist = await _context.Customers.FirstOrDefaultAsync(x => x.ID == ID);

            if (exist == null)
                return false;

            _context.Customers.Remove(exist);

            if (change.FirstName != null)
                exist.FirstName = change.FirstName;
            if (change.LastName != null)
                exist.LastName = change.LastName;
            if (change.CompanyName != null)
                exist.CompanyName = change.CompanyName;
            if (newAddress != default(int))
                exist.Address = await _AddRepo.GetAddress(newAddress);
            if (change.PhoneNumber != null)
                exist.PhoneNumber = change.PhoneNumber;
            if (change.Email != null)
                exist.Email = change.Email;

            await _context.Customers.AddAsync(exist);
            await _context.SaveChangesAsync();
            
            return true;
        }

    }
}