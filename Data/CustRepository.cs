using System;
using System.Threading.Tasks;
using CheckIT.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Data
{
    public class CustRepository : ICustRepository
    {
        private readonly DataContext _context;
        public CustRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Customer> CreateCustomer(Customer customer)
        {

            //save to database.
            await _context.Customers.AddAsync(customer); //to be added to DataContext
            await _context.SaveChangesAsync();

            return user;
        }

    }
}