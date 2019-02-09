using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckIT.API.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Data
{
    public class BusinessRepository
    {
        private readonly DataContext _context;
        public BusinessRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Business> AddBusiness(Business newBusiness)
        {
            await _context.Businesses.AddAsync(newBusiness);
            await _context.SaveChangesAsync();

            return newBusiness;
        }

        public async Task<Business> GetBusiness(int BusinessID)
        {
            Business business = await _context.Businesses.FirstOrDefaultAsync(x => x.Id == BusinessID);
            return business;
        }

        public async Task<List<Business>> GetAllBusinesses()
        {
            List<Business> businesses = await _context.Businesses.ToListAsync();
            return businesses;
        }

        public async Task<Business> DeleteLocation(int businessID)
        {
            var business = await _context.Businesses.FirstOrDefaultAsync(x => x.Id == businessID);

            if(business == null)
            {
                return null;
            }
            else
            {
                _context.Businesses.Remove(business);
            }

            await _context.SaveChangesAsync();

            return business;
        }
    }
}