﻿using HermanTheBrokerAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

// update-database 0
// remove-migration
// add-migration "Init"
// update-database

namespace HermanTheBrokerAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Broker> Broker { get; set; }
        public DbSet<House> House { get; set; }
        //public DbSet<AspNetUsers> AspNetUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Broker>().HasData(new Broker { ID = 1, Name = "Jeff", PhoneNumber=456 });
            //modelBuilder.Entity<Broker>().HasData(new Broker { Name = "Kerry", ID = 2 });
            //modelBuilder.Entity<Broker>().HasData(new Broker { Name = "Tom", ID = 3 });
            //modelBuilder.Entity<Broker>().HasData(new Broker { Name = "Dave", ID = 4 });

            modelBuilder.Entity<House>().HasData(
             new House
             {
                 HouseId = 1,
                 Street = "Storgatan",
                 City = "Vänersborg",
                 Area = 200,
                 BuildYear = 1984,
                 NoOfFloors = 2,
                 NoOfRooms = 7,
                 Category = Category.Villa,
                 ID = 1,
                 HermanTheBrokerAPIUser = new()
                 {
                     Email = "c@a.com",
                     Id = "a23",
                     //HermanTheBrokerAPIUserId = 1,
                 },
             }
         );

            //modelBuilder.Entity<House>().HasData(
            //    new House
            //    {
            //        HouseId = 2,
            //        Street = "Drottninggatan",
            //        City = "Trollhättan",
            //        Area = 123,
            //        BuildYear = 1999,
            //        NoOfFloors = 1,
            //        NoOfRooms = 4,
            //        ID = 2
            //    }
            //);
            //modelBuilder.Entity<House>().HasData(
            //    new House
            //    {
            //        HouseId = 3,
            //        Street = "Kungsgatan",
            //        City = "Uddevalla",
            //        Area = 80,
            //        BuildYear = 1909,
            //        NoOfFloors = 1,
            //        NoOfRooms = 2,
            //        ID = 3
            //    }
            //);
            //modelBuilder.Entity<House>().HasData(
            //    new House
            //    {
            //        HouseId = 4,
            //        Street = "Odinsgatan",
            //        City = "Grästorp",
            //        Area = 275,
            //        BuildYear = 2011,
            //        NoOfFloors = 3,
            //        NoOfRooms = 8,
            //        ID = 4
            //    }
            //);
        }
    }
}
