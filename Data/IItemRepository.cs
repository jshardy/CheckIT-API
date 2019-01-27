using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckIT.API.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Data
{
    public interface IItemRepository
    {
        Task<Item> AddItem(Item item);
        Task<Item> GetItem(int ID);
        Task<List<Item>> GetAllItems();
        Task<Item> DeleteItem(int itemID);
        Task<Item> UpdateItem(Item item);

    }
}