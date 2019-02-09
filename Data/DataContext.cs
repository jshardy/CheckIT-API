using CheckIT.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<LineItem>().HasKey(li => new { li.InvoiceID, li.IventoryID });

            // modelBuilder.Entity<Invoice>().HasOne<Customer>(x => x.Customer)
            //                             .WithMany(x => x.Invoices)
            //                             .HasForeignKey(x => x.CustInvoiceID);

            // modelBuilder.Entity<Address>().HasOne<Customer>(x => x.Customer)
            //                             .WithMany(x => x.Addresses)
            //                             .HasForeignKey(x => x.CustAddressID);
            
            // modelBuilder.Entity<LineItem>().HasOne<Invoice>(x => x.Invoice)
            //                             .WithMany(x => x.LineItems)
            //                             .HasForeignKey(x => x.InvoiceLineID);

            // modelBuilder.Entity<LineItem>().HasOne<Inventory>(x => x.Inventory)
            //                             .WithMany(x => LineItems)
            //                             .HasForeignKey(x => x.InventoryLineID);

            // modelBuilder.Entity<Location>().HasOne<Inventory>(x => x.Inventory)
            //                             .WithMany(x => x.Locations)
            //                             .HasForeignKey(x => x.LocationInventoryID);

            // modelBuilder.Entity<Alert>().HasOne<Inventory>(x => x.Inventory)
            //                             .WithMany(x => Alerts)
            //                             .HasForeignKey(x => x.AlertInventoryID);
        }  

        public DbSet<User> Users { get; set; }
        public DbSet<Invoice> Invoices {get; set;}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
    }
}