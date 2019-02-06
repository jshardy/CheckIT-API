using CheckIT.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<LineItem> LineItems {get; set; }

        // configures InvoiceID and ItemID as the composite key.
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<LineItem>().HasKey(li => new { li.InvoiceID, li.ItemID });
        // }

        public DbSet<User> Users { get; set; }
        public DbSet<Invoice> Invoices {get; set;}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}