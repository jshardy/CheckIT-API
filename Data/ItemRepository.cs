using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckIT.API.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Data
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext _context;
        public ItemRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Item> AddItem(Item item)
        {
            //save to database.
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<Item> GetItem(int ID)
        {
            Item item = await _context.Items.FirstOrDefaultAsync(x => x.Id == ID);
            return item;
        }

        public async Task<List<Item>> GetAllItems()
        {
            List<Item> items = await _context.Items.ToListAsync();
            return items;
        }

        public async Task<Item> DeleteItem(int itemID)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == itemID);

            if(item == null)
            {
                return null;
            }
            else
            {
                _context.Items.Remove(item);
            }

            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<Item> UpdateItem(Item item)
        {
            //update database.
            //await _context.Items.AddAsync(item);
            _context.Items.Update(item); //Async? even need to use update?
            await _context.SaveChangesAsync();

            return item;
        }
        /*
        public async Task<bool> ItemExists(string name)
        {
            if(await _context.Items.AnyAsync(x => x.Name == name))
                return true;

            return false;
        }
        */
    }
}