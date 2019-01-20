using CheckIT.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Invoice> Invoices {get; set;}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}