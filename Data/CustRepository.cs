using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CheckIT.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Data
{
    public class CustRepository
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

            customer.CustAddress = await _AddRepo.GetAddress(AddressId);

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
                exist.CustAddress = await _AddRepo.GetAddress(newAddress);
            if (change.PhoneNumber != null)
                exist.PhoneNumber = change.PhoneNumber;
            if (change.Email != null)
                exist.Email = change.Email;

            await _context.Customers.AddAsync(exist);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ICollection<Customer>> GetCustomersByFirstName(string firstName)
        {
            ICollection<Customer> customers = await _context.Customers.Where(x => x.FirstName == firstName).ToListAsync();
            return customers;
        }

        public async Task<ICollection<Customer>> GetCustomersByLastName(string lastName)
        {
            ICollection<Customer> customers = await _context.Customers.Where(x => x.LastName == lastName).ToListAsync();
            return customers;
        }
        public async Task<ICollection<Customer>> GetCustomersByCompanyName(string companyName)
        {
            ICollection<Customer> customers = await _context.Customers.Where(x => x.CompanyName == companyName).ToListAsync();
            return customers;
        }
        public async Task<ICollection<Customer>> GetCustomersByAddress(Address address)
        {
            ICollection<Customer> customers = await _context.Customers.Where(x => x.CustAddress == address).ToListAsync();
            return customers;
        }
        public async Task<ICollection<Customer>> GetCustomersByPhoneNumber(string phone)
        {
            ICollection<Customer> customers = await _context.Customers.Where(x => x.PhoneNumber == phone).ToListAsync();
            return customers;
        }
        public async Task<ICollection<Customer>> GetCustomersByEmail(string email)
        {
            ICollection<Customer> customers = await _context.Customers.Where(x => x.Email == email).ToListAsync();
            return customers;
        }

    }
}