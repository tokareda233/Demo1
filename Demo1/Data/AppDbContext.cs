using System.Diagnostics;
using System.Drawing;
using Demo1.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerProfile> CustomerProfiles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<Vehicle>()
                .HasIndex(c => c.VIN)
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.DriverLicenseNumber)
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasIndex(c => c.Email)
                .IsUnique();



            modelBuilder.Entity<Vehicle>()
              .Property(c => c.Price)
              .HasPrecision(12, 2);

            modelBuilder.Entity<Sale>()
             .Property(c => c.SalePrice)
             .HasPrecision(12, 2);

            modelBuilder.Entity<Vehicle>()
                .Property(c => c.Status)
                .HasDefaultValue("Available");

            modelBuilder.Entity<Vehicle>()
                .HasOne(c => c.Category)
                .WithMany(x => x.Vehicles)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Customer>()
               .HasMany(c => c.sales)
               .WithOne(x => x.Customer)
               .HasForeignKey(x => x.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
               .HasMany(c => c.Sales)
               .WithOne(x => x.Employee)
               .HasForeignKey(x => x.EmployeeId)
               .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Vehicle>()
                .HasOne(c => c.Sale)
                .WithOne(x => x.Vehicle)
                .HasForeignKey<Sale>(x => x.Vehicleid)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Customer>()
                .HasOne(c => c.CustomerProfile)
                .WithOne(x => x.Customer)
                .HasForeignKey<CustomerProfile>(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);



            //modelBuilder.Entity<Category>()
            //    .HasData(
            //    new Category
            //    {
            //        Id = 1,
            //        Name = "Sedan",
            //        Description = "Comfortable passenger cars"

            //    },
            //     new Category
            //     {
            //         Id = 2,
            //         Name = "SUV",
            //         Description = "Sport utility vehicles"

            //     },
            //      new Category
            //      {
            //          Id = 3,
            //          Name = "Hatchback",
            //          Description = "Compact practical cars"

            //      }

            //    );


            //modelBuilder.Entity<Vehicle>()
            //    .HasData(
            //new Vehicle
            //{
            //    Id = 1,
            //    Make = "Toyota",
            //    Model = "Corolla",
            //    Year = 2024,
            //    color = "White",
            //    Price = 650000,
            //    Mileage = 12000,
            //    VIN = "VIN001",
            //    FuelType = "Petrol",
            //    Transmission = "Automatic",
            //    Status = "Available",
            //    CategoryId = 1,
            //},
            // new Vehicle
            // {
            //     Id = 2,
            //     Make = "Toyota2",
            //     Model = "Corolla2",
            //     Year = 2023,
            //     color = "Black",
            //     Price = 590000,
            //     Mileage = 18000,
            //     VIN = "VIN00002",
            //     FuelType = "Petrol",
            //     Transmission = "Automatic",
            //     Status = "Available",
            //     CategoryId = 2,
            // },
            //  new Vehicle
            //  {
            //      Id = 3,
            //      Make = "Toyota3",
            //      Model = "Corolla3",
            //      Year = 2024,
            //      color = "Gray",
            //      Price = 980000,
            //      Mileage = 9000,
            //      VIN = "VIN0000000003",
            //      FuelType = "Petrol",
            //      Transmission = "Automatic",
            //      Status = "Available",
            //      CategoryId = 3,
            //  }


            //    );

            //modelBuilder.Entity<Customer>()
            //    .HasData(
            //    new Customer
            //    {
            //        Id = 1,
            //        FullName = "Toka Reda",
            //        Email = "Toka@gmail.com",
            //        Phone = "01120099839",
            //        DriverLicenseNumber = "DL100001",

            //    },
            //     new Customer
            //     {
            //         Id = 2,
            //         FullName = "Yomna Reda",
            //         Email = "Yomna@gmail.com",
            //         Phone = "01120099839",
            //         DriverLicenseNumber = "DL100002",

            //     },
            //      new Customer
            //      {
            //          Id = 3,
            //          FullName = "Haneen Reda",
            //          Email = "Haneen@gmail.com",
            //          Phone = "01120099839",
            //          DriverLicenseNumber = "DL100003",

            //      }

            //    );

            //modelBuilder.Entity<CustomerProfile>()
            //    .HasData(
            //    new CustomerProfile
            //    {
            //        Id = 1,
            //        Address = "12 Nile St.",
            //        City = "Cairo",
            //        Nationality = "Egyptian",
            //        DateOfBirth = new DateTime(1992 - 03 - 12),
            //        CustomerId = 1,

            //    },
            //     new CustomerProfile
            //     {
            //         Id = 2,
            //         Address = "13 Nile St.",
            //         City = "Giza",
            //         Nationality = "Egyptian",
            //         DateOfBirth = new DateTime(1995 - 07 - 24),
            //         CustomerId = 2,

            //     },
            //      new CustomerProfile
            //      {
            //          Id = 3,
            //          Address = "12 Nile St.",
            //          City = "Cairo",
            //          Nationality = "Egyptian",
            //          DateOfBirth = new DateTime(1988 - 11 - 05),
            //          CustomerId = 3,

            //      }

            //    );


            //modelBuilder.Entity<Employee>()
            //    .HasData(
            //    new Employee
            //    {
            //        Id = 1,
            //        FullName = "Tpka Reda",
            //        Position = "Sales Manager",
            //        Email = "mostafa.nabil@autodrive.com",
            //        Phone = "01120099839",
            //        HireDate = new DateTime(2021 - 01 - 10),

            //    },

            //     new Employee
            //     {
            //         Id = 2,
            //         FullName = "Yomna Reda",
            //         Position = "SalesConsultant",
            //         Email = "aya.emad@autodrive.com",
            //         Phone = "01120099839",
            //         HireDate = new DateTime(2024 - 04 - 15),

            //     },
            //      new Employee
            //      {
            //          Id = 3,
            //          FullName = "Haneen Reda",
            //          Position = "Sales Manager",
            //          Email = "hassan.ali@autodrive.com",
            //          Phone = "01120099839",
            //          HireDate = new DateTime(2023 - 02 - 20),

            //      }

            //    );

            //modelBuilder.Entity<Sale>()
            //    .HasData(new Sale
            //    {
            //        Id = 1,
            //        SaleDate = new DateTime(2026 - 08 - 15),
            //        SalePrice = 1750000,
            //        PaymentMethod = "Bank Transfer",
            //        Notes = "Completed sale.",
            //        CustomerId = 1,
            //        EmployeeId = 1,
            //        Vehicleid = 1,

            //    },
            //    new Sale
            //    {
            //        Id = 2,
            //        SaleDate = new DateTime(2026 - 08 - 22),
            //        SalePrice = 1850000,
            //        PaymentMethod = "Bank Transfer",
            //        Notes = "Completed sale.",
            //        CustomerId = 2,
            //        EmployeeId = 2,
            //        Vehicleid = 2,

            //    }, new Sale
            //    {
            //        Id = 3,
            //        SaleDate = new DateTime(2026 - 09 - 05),
            //        SalePrice = 510000,
            //        PaymentMethod = "Bank Transfer",
            //        Notes = "Cash",
            //        CustomerId = 3,
            //        EmployeeId = 3,
            //        Vehicleid = 3,

            //    }
            //    );
        }




    }
}
