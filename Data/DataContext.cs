using CheckIT.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Location>().OnDelete(DeleteBehavior.SetNull);
            // modelBuilder.Entity<Alert>().OnDelete(DeleteBehavior.SetNull);
            // modelBuilder.Entity<Address>().OnDelete(DeleteBehavior.SetNull);
            // modelBuilder.Entity<LineItem>().OnDelete(DeleteBehavior.SetNull);
            // modelBuilder.Entity<Invoice>().OnDelete(DeleteBehavior.SetNull);
            // modelBuilder.Entity<Customer>().OnDelete(DeleteBehavior.SetNull);
            // modelBuilder.Entity<Inventory>().OnDelete(DeleteBehavior.SetNull);

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Invoice> Invoices {get; set;}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
    }
}