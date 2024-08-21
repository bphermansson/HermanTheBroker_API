using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HermanTheBrokerAPI.Models;
using System.Reflection.Emit;

namespace HermanTheBrokerAPI.Areas.Identity.Data;

public class HermanTheBrokerAPIContext : IdentityDbContext<Broker>
{
    public HermanTheBrokerAPIContext(DbContextOptions<HermanTheBrokerAPIContext> options)
        : base(options)
    {
    }
    public DbSet<House> House { get; set; }
    public DbSet<Broker> Broker { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //builder.Entity<House>().HasData(
        //    new Broker
        //    {
        //        Email = "c@a.com",
        //        Id = "a23",
        //    }
        //    );

        //builder.Entity<House>().HasData(
        //     new House
        //     {
        //         HouseId = 1,
        //         Street = "Storgatan",
        //         City = "Vänersborg",
        //         Area = 200,
        //         BuildYear = 1984,
        //         NoOfFloors = 2,
        //         NoOfRooms = 7,
        //         Category = Category.Villa,
        //         ID = 1,
        //         //HermanTheBrokerAPIUserId = "a23"
        //     }
        //    );
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
