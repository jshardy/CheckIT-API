using CheckIT.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Invoice> Invoices {get; set;}
<<<<<<< HEAD
        
        public DbSet<Item> Items { get; set; }
=======
        // public DbSet<Item> Items { get; set; }
>>>>>>> 19993d04cf51fe3f4621f3e618e30f3e35cd494e
    }
}