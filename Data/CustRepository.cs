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
        public async Task<Customer> CreateCustomer(Customer customer)
        {

            //save to database.
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public int GetCustomerID(Customer toFind)
        {
            return toFind.Id;
        }

        public async Task<Customer> GetCustomer(int ID)
        {
            Customer cust = await _context.Customers.Include(x => x.CustAddress)
                                                    .Include(x => x.CustomerInvoiceList)
                                                        .ThenInclude(x => x.InvoicesLineList)
                                                    .FirstOrDefaultAsync(x => x.Id == ID);
            return cust;
        }

        public async Task<bool> DeleteCustomer(int ID)
        {
            Customer cust = await _context.Customers.FirstOrDefaultAsync(x => x.Id == ID);

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
            Customer exist = await _context.Customers.FirstOrDefaultAsync(x => x.Id == ID);

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

        public async Task<IEnumerable<Customer>> GetCustomers(string FirstName, 
                                                            string LastName, 
                                                            string CompanyName, 
                                                            bool IsCompany,
                                                            string PhoneNumber,
                                                            string Email)
        {


            IQueryable<Customer> query = _context.Customers;

            if(FirstName != "")
            {
                query = query.Where(p => p.FirstName.Contains(FirstName));
            }

            if(LastName != "")
            {
                query = query.Where(p => p.LastName.Contains(LastName));
            }

            if(CompanyName != "")
            {
                query = query.Where(p => p.CompanyName.Contains(CompanyName));
            }

            if(IsCompany)
            {
                query = query.Where(p => p.IsCompany == true);
            }

            if(PhoneNumber != "")
            {
                query = query.Where(p => p.PhoneNumber.Contains(PhoneNumber));
            }

            if(Email != "")
            {
                query = query.Where(p => p.Email.Contains(Email));
            }

            return await query.ToListAsync();
        }

    }
}