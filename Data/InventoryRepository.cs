using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckIT.API.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Data
{
    public class InventoryRepository
    {
        private readonly DataContext _context;
        public InventoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Inventory> AddInventory(Inventory inventory)
        {
            //save to database.
            await _context.Inventories.AddAsync(inventory);
            await _context.SaveChangesAsync();

            return inventory;
        }

        public async Task<Inventory> GetInventory(int ID)
        {
            Inventory inventory = await _context.Inventories.FirstOrDefaultAsync(x => x.Id == ID);
            return inventory;
        }

        public async Task<List<Inventory>> GetAllInventories()
        {
            List<Inventory> items = await _context.Inventories.ToListAsync();
            return items;
        }

        public async Task<Inventory> ArchiveInventory(int itemID)
        {
            var inventory = await _context.Inventories.FirstOrDefaultAsync(x => x.Id == itemID);

            if(inventory == null)
            {
                return null;
            }
            else
            {
                inventory.Archived = true;
                _context.Inventories.Update(inventory);
                //_context.Inventory.Remove(inventory); //removes inventory from database completely
            }

            await _context.SaveChangesAsync();

            return inventory;
        }

        public async Task<Inventory> DeleteInventory(int itemID)
        {
            var inventory = await _context.Inventories.FirstOrDefaultAsync(x => x.Id == itemID);

            if(inventory == null)
            {
                return null;
            }
            else
            {
                _context.Inventories.Remove(inventory); //removes inventory from database completely
            }

            await _context.SaveChangesAsync();

            return inventory;
        }

        public async Task<Inventory> UpdateInventory(Inventory inventory)
        {
            //update database
            //await _context.Inventory.AddAsync(inventory);
            _context.Inventories.Update(inventory); //Async? even need to use update?
            await _context.SaveChangesAsync();

            return inventory;
        }
        /*
        public async Task<bool> InventoryExists(string name)
        {
            if(await _context.Inventory.AnyAsync(x => x.Name == name))
                return true;

            return false;
        }
        */
    }
}