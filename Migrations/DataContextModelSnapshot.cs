﻿// <auto-generated />
using System;
using CheckIT.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CheckIT.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("CheckIT.API.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AptNum");

                    b.Property<string>("Country");

                    b.Property<bool>("DefaultAddress");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CheckIT.API.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressID");

                    b.Property<string>("CompanyName");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CheckIT.API.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("AmmountPaid");

                    b.Property<int>("BusinessID");

                    b.Property<bool>("IncomingInv");

                    b.Property<DateTime>("InvoiceDate");

                    b.Property<bool>("OutgoingInv");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("CheckIT.API.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("InvoiceId");

                    b.Property<string>("Name");

                    b.Property<float>("Price");

                    b.Property<int>("Quantity");

                    b.Property<int>("UPC");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("CheckIT.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CheckIT.API.Models.Item", b =>
                {
                    b.HasOne("CheckIT.API.Models.Invoice")
                        .WithMany("Items")
                        .HasForeignKey("InvoiceId");
                });
#pragma warning restore 612, 618
        }
    }
}
