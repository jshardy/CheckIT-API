﻿// <auto-generated />
using System;
using CheckIT.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CheckIT.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190503231604_Added realmId toekn to User Model")]
    partial class AddedrealmIdtoekntoUserModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CheckIT.API.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressCustID");

                    b.Property<string>("AptNum");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("AddressCustID")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CheckIT.API.Models.Alert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AlertOn");

                    b.Property<bool>("AlertTriggered");

                    b.Property<DateTime>("DateOrdered");

                    b.Property<DateTime>("DateUnder");

                    b.Property<int>("Threshold");

                    b.HasKey("Id");

                    b.ToTable("Alerts");
                });

            modelBuilder.Entity("CheckIT.API.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsCompany");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CheckIT.API.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Archived");

                    b.Property<string>("Description");

                    b.Property<int>("InventoryAlertID");

                    b.Property<int>("InventoryLocationID");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price")
                        .HasColumnType("Money");

                    b.Property<int>("Quantity");

                    b.Property<string>("UPC");

                    b.HasKey("Id");

                    b.HasIndex("InventoryAlertID")
                        .IsUnique();

                    b.HasIndex("InventoryLocationID");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("CheckIT.API.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AmountPaid")
                        .HasColumnType("Money");

                    b.Property<decimal>("Discount");

                    b.Property<int>("InvoiceCustID");

                    b.Property<DateTime>("InvoiceDate");

                    b.Property<bool>("OutgoingInv");

                    b.Property<decimal>("Tax");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceCustID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("CheckIT.API.Models.LineItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LineInventoryID");

                    b.Property<int>("LineInvoiceID");

                    b.Property<decimal>("Price")
                        .HasColumnType("Money");

                    b.Property<int>("QuantitySold");

                    b.HasKey("Id");

                    b.HasIndex("LineInventoryID");

                    b.HasIndex("LineInvoiceID");

                    b.ToTable("LineItems");
                });

            modelBuilder.Entity("CheckIT.API.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("CheckIT.API.Models.Permissions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AddAlert");

                    b.Property<bool>("AddCustomer");

                    b.Property<bool>("AddInvoice");

                    b.Property<bool>("AddIventory");

                    b.Property<bool>("AddLocation");

                    b.Property<bool>("ArchiveInvoice");

                    b.Property<bool>("ArchiveIventory");

                    b.Property<bool>("DeleteAlert");

                    b.Property<bool>("DeleteCustomer");

                    b.Property<bool>("DeleteLocation");

                    b.Property<int>("Level");

                    b.Property<int>("PermissionsUserId");

                    b.Property<bool>("SetUserPermissions");

                    b.Property<bool>("UpdateAlert");

                    b.Property<bool>("UpdateCustomer");

                    b.Property<bool>("UpdateInventory");

                    b.Property<bool>("UpdateInvoice");

                    b.Property<bool>("ViewAlert");

                    b.Property<bool>("ViewCustomer");

                    b.Property<bool>("ViewInventory");

                    b.Property<bool>("ViewInvoice");

                    b.Property<bool>("ViewLocation");

                    b.Property<bool>("ViewUserPermissions");

                    b.HasKey("Id");

                    b.HasIndex("PermissionsUserId")
                        .IsUnique();

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("CheckIT.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApiAuthToken");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Username");

                    b.Property<int>("realmID");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CheckIT.API.Models.Address", b =>
                {
                    b.HasOne("CheckIT.API.Models.Customer", "AddressCust")
                        .WithOne("CustAddress")
                        .HasForeignKey("CheckIT.API.Models.Address", "AddressCustID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CheckIT.API.Models.Inventory", b =>
                {
                    b.HasOne("CheckIT.API.Models.Alert", "InventoryAlert")
                        .WithOne("AlertInv")
                        .HasForeignKey("CheckIT.API.Models.Inventory", "InventoryAlertID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CheckIT.API.Models.Location", "InventoryLocation")
                        .WithMany("InventoryLocList")
                        .HasForeignKey("InventoryLocationID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CheckIT.API.Models.Invoice", b =>
                {
                    b.HasOne("CheckIT.API.Models.Customer", "InvoiceCust")
                        .WithMany("CustomerInvoiceList")
                        .HasForeignKey("InvoiceCustID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CheckIT.API.Models.LineItem", b =>
                {
                    b.HasOne("CheckIT.API.Models.Inventory", "LineInventory")
                        .WithMany("InventoryLineList")
                        .HasForeignKey("LineInventoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CheckIT.API.Models.Invoice", "LineInvoice")
                        .WithMany("InvoicesLineList")
                        .HasForeignKey("LineInvoiceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CheckIT.API.Models.Permissions", b =>
                {
                    b.HasOne("CheckIT.API.Models.User", "PermissionsUser")
                        .WithOne("UserPermissions")
                        .HasForeignKey("CheckIT.API.Models.Permissions", "PermissionsUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
