using System.Threading.Tasks;
using CheckIT.API.Models;

namespace CheckIT.API.Data
{
    public interface IItemRepository
    {
        Task<Item> AddItem(Item item);
        //Task<bool> ItemExists(string name);
    }
}