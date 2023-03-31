using Microsoft.EntityFrameworkCore;
using RentalCarCore.Entities;
using System;

namespace CarRentalInfrestructure
{
    public class RentalContext : DbContext
    {
        public RentalContext(DbContextOptions<RentalContext> options) : base(options)
        {

        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<RentalPrice> RentalPrices { get; set; }
        public DbSet<VehicleBrand> VehicleBrands { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                 new User { Id = 1, Active = true, DateRegistered = DateTime.Today, Name = "Administrator", UserName = "admin@admin.com.edu",Password = "58-1E-F2-49-67-4E-81-CB-DD-20-28-F3-6C-81-82-08-47-CE-95-EB-A2-F2-C2-BF-F3-E5-2D-2E-BB-DF-2F-4E-E3-F2-AB-44-8C-E4-5D-AA-DF-AE-BB-70-79-5D-97-15-4E-03-F9-9B-31-96-12-E9-D5-BB-C9-C6-26-6B-98-7C", Salt= "umW6RniM+YY=" }
                 );

            modelBuilder.Entity<VehicleType>().HasData(
                new VehicleType { Id = 1, Active = true, Description = "SUV" },
                new VehicleType { Id = 2, Active = true, Description = "Economy" },
                new VehicleType { Id = 3, Active = true, Description = "Luxury" });


            modelBuilder.Entity<VehicleBrand>().HasData(
                new VehicleBrand { Id = 1, Active = true, Description = "Ford" },
                new VehicleBrand { Id = 2, Active = true, Description = "Suzuki" },
                new VehicleBrand { Id = 3, Active = true, Description = "Toyota" });


            modelBuilder.Entity<VehicleModel>().HasData(
                new VehicleModel { Id = 1, Active = true, Name = "Kuga", BrandID = 1, Doors = 5, Seats = 5, Airbags = 4, Trunk = true, VehicleTypeID = 1 },
                new VehicleModel { Id = 2, Active = true, Name = "Jimny", BrandID = 2, Doors = 5, Seats = 5, Airbags = 4, Trunk = true, VehicleTypeID = 1 },
                new VehicleModel { Id = 3, Active = true, Name = "RAV4", BrandID = 3, Doors = 5, Seats = 5, Airbags = 4, Trunk = true, VehicleTypeID = 1 },
                new VehicleModel { Id = 4, Active = true, Name = "Fiesta", BrandID = 1, Doors = 3, Seats = 5, Airbags = 2, Trunk = false, VehicleTypeID = 2 },
                new VehicleModel { Id = 5, Active = true, Name = "Swift", BrandID = 2, Doors = 5, Seats = 5, Airbags = 2, Trunk = false, VehicleTypeID = 2 },
                new VehicleModel { Id = 6, Active = true, Name = "Etios", BrandID = 3, Doors = 5, Seats = 5, Airbags = 2, Trunk = false, VehicleTypeID = 2 },
                new VehicleModel { Id = 7, Active = true, Name = "Lincoln", BrandID = 1, Doors = 3, Seats = 5, Airbags = 6, Trunk = false, VehicleTypeID = 3 },
                new VehicleModel { Id = 8, Active = true, Name = "Maruti 800", BrandID = 2, Doors = 5, Seats = 5, Airbags = 6, Trunk = false, VehicleTypeID = 3 },
                new VehicleModel { Id = 9, Active = true, Name = "Corolla", BrandID = 3, Doors = 5, Seats = 5, Airbags = 6, Trunk = false, VehicleTypeID = 3 });


            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, Active = true, ModelID = 1, DateCreation=DateTime.Now, UserIDCreation=1, Domain = "Domain1" }, new Vehicle { Id = 2, Active = true, ModelID = 1, DateCreation = DateTime.Now, UserIDCreation = 1 , Domain = "Domain2" }, new Vehicle { Id = 3, Active = true, ModelID = 1, DateCreation = DateTime.Now, UserIDCreation = 1, Domain="Domain3" },
                new Vehicle { Id = 4, Active = true, ModelID = 2, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain4" }, new Vehicle { Id = 5, Active = true, ModelID = 2, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain5" }, new Vehicle { Id = 6, Active = true, ModelID = 2, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain6" },
                new Vehicle { Id = 7, Active = true, ModelID = 3, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain7" }, new Vehicle { Id = 8, Active = true, ModelID = 3, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain8" }, new Vehicle { Id = 9, Active = true, ModelID = 3, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain9" },
                new Vehicle { Id = 10, Active = true, ModelID = 4, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain10" }, new Vehicle { Id = 11, Active = true, ModelID = 4, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain11" }, new Vehicle { Id = 12, Active = true, ModelID = 4, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain12" },
                new Vehicle { Id = 13, Active = true, ModelID = 5, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain13" }, new Vehicle { Id = 14, Active = true, ModelID = 5, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain14" }, new Vehicle { Id = 15, Active = true, ModelID = 5, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain15" },
                new Vehicle { Id = 16, Active = true, ModelID = 6, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain16" }, new Vehicle { Id = 17, Active = true, ModelID = 6, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain17" }, new Vehicle { Id = 18, Active = true, ModelID = 6, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain18" },
                new Vehicle { Id = 19, Active = true, ModelID = 7, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain19" }, new Vehicle { Id = 20, Active = true, ModelID = 7, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain20" }, new Vehicle { Id = 21, Active = true, ModelID = 7, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain21" },
                new Vehicle { Id = 22, Active = true, ModelID = 8, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain22" }, new Vehicle { Id = 23, Active = true, ModelID = 8, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain23" }, new Vehicle { Id = 24, Active = true, ModelID = 8, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain24" },
                new Vehicle { Id = 25, Active = true, ModelID = 9, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain25" }, new Vehicle { Id = 26, Active = true, ModelID = 9, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain26" }, new Vehicle { Id = 27, Active = true, ModelID = 9, DateCreation = DateTime.Now, UserIDCreation = 1, Domain = "Domain27" }
                );

            modelBuilder.Entity<Customer>().HasData(
                 new Customer { Id = 1, Active = true, DateRegistered = DateTime.Today, Direction="Direction 1", FullName="Customer 1" , IdCard= "IdCard1" },
                 new Customer { Id = 2, Active = true, DateRegistered = DateTime.Today, Direction = "Direction 2", FullName = "Customer 2", IdCard = "IdCard2" }, 
                 new Customer { Id = 3, Active = true, DateRegistered = DateTime.Today, Direction = "Direction 3", FullName = "Customer 3", IdCard = "IdCard3" }
                 );


            modelBuilder.Entity<RentalPrice>().HasData(
                 new RentalPrice { Id = 1, Active = true, DateFrom=DateTime.Today.AddMonths(-2), DateTo = DateTime.Today.AddMonths(2), ModelID=1, PricePerDay=200 },
                 new RentalPrice { Id = 2, Active = true, DateFrom = DateTime.Today.AddMonths(-2), DateTo = DateTime.Today.AddMonths(2), ModelID = 2, PricePerDay = 300 },
                 new RentalPrice { Id = 3, Active = true, DateFrom = DateTime.Today.AddMonths(-2), DateTo = DateTime.Today.AddMonths(2), ModelID = 3, PricePerDay = 400 },
                 new RentalPrice { Id = 4, Active = true, DateFrom = DateTime.Today.AddMonths(-2), DateTo = DateTime.Today.AddMonths(2), ModelID = 4, PricePerDay = 500 },
                 new RentalPrice { Id = 5, Active = true, DateFrom = DateTime.Today.AddMonths(-2), DateTo = DateTime.Today.AddMonths(2), ModelID = 5, PricePerDay = 600 },
                 new RentalPrice { Id = 6, Active = true, DateFrom = DateTime.Today.AddMonths(-2), DateTo = DateTime.Today.AddMonths(2), ModelID = 6, PricePerDay = 700 },
                 new RentalPrice { Id = 7, Active = true, DateFrom = DateTime.Today.AddMonths(-2), DateTo = DateTime.Today.AddMonths(2), ModelID = 7, PricePerDay = 800 },
                 new RentalPrice { Id = 8, Active = true, DateFrom = DateTime.Today.AddMonths(-2), DateTo = DateTime.Today.AddMonths(2), ModelID = 8, PricePerDay = 900 },
                 new RentalPrice { Id = 9, Active = true, DateFrom = DateTime.Today.AddMonths(-2), DateTo = DateTime.Today.AddMonths(2), ModelID = 9, PricePerDay = 1000 }
                 );


        }

    }
}
