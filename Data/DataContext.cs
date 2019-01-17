using CheckIT.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
<<<<<<< HEAD
        public DbSet<Invoice> Invoices {get; set;}
        
=======
        public DbSet<Item> Items { get; set; }
>>>>>>> ee849db71c6be910fd2922779537e0feee472aed
    }
}