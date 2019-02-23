using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckIT.API.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Data
{
    public class LocRepository
    {
        private readonly DataContext _context;
        public LocRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Location> AddLocation(Location loc)
        {
            //save to database.
            await _context.Locations.AddAsync(loc);
            await _context.SaveChangesAsync();

            return loc;
        }

        public async Task<Location> GetLocation(int locID)
        {
            Location loc = await _context.Locations.Include(p => p.InventoryLocList)
                                                   .FirstOrDefaultAsync(x => x.Id == locID);
            return loc;
        }

        public async Task<List<Location>> GetAllLocations()
        {
            List<Location> locs = await _context.Locations.ToListAsync();
            return locs;
        }

        public async Task<IEnumerable<Location>> GetLocations(string Name, int LocInvID)
        {
            IQueryable<Location> query = _context.Locations;

            if(Name != null)
            {
                query = query.Where(p => p.Name.Contains(Name));
            }

            if(LocInvID != -1)
            {
                query = query.Where(p => p.InventoryLocList.Equals(LocInvID));
            }

            return await query.ToListAsync();
        }

        public async Task<Location> DeleteLocation(int locID)
        {
            var loc = await _context.Locations.FirstOrDefaultAsync(x => x.Id == locID);

            if(loc == null)
            {
                return null;
            }
            else
            {
                _context.Locations.Remove(loc);
            }

            await _context.SaveChangesAsync();

            return loc;
        }
    }
}