using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HermanTheBrokerAPI.Models;
using System.Reflection.Emit;
using System.Reflection.Metadata;

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
        builder.Entity<Broker>()
           .HasMany(e => e.Houses)
            .WithOne(e => e.Broker)
            .HasForeignKey(e => e.BrokerId) // Key in the other table
            .HasPrincipalKey(e => e.Id); // Key in this table

        builder.Entity<Broker>().HasData(
            new Broker
            {
                Email = "a@a.com",
                Id = "b58",
                Name = "James"
            }
        );

        builder.Entity<House>().HasData(
             new House
             {
                 HouseId = 1,
                 Category = Category.Villa,
                 PostalAddress = "Storgatan 3",
                 City = "Vänersborg",
                 AskingPrice = 2350000,
                 LivingArea = 210,
                 SecondaryArea = 20,
                 GardenArea = 1200,
                 Description = "Det första huset.",
                 NoOfRooms = 6,
                 MonthlyFee = 0,
                 YearlyRunningCosts = 36000,
                 BuildYear = 1973,
                 Error = false,
                 BrokerId = "b58"
             }
            );
        builder.Entity<House>().HasData(
            new House
            {
                HouseId = 2,
                Category = Category.Bostadsrättslägenhet,
                PostalAddress = "Kungsgatan 10",
                City = "Grästorp",
                AskingPrice = 200000,
                LivingArea = 56,
                SecondaryArea = 0,
                GardenArea = 0,
                Description = "Den första lägenheten.",
                NoOfRooms = 2,
                MonthlyFee = 5500,
                YearlyRunningCosts = 3000,
                BuildYear = 2021,
                Error = false,
                BrokerId = "b58"
            }
        );
        builder.Entity<House>().HasData(
            new House
            {
                HouseId = 3,
                Category = Category.Fritidshus,
                PostalAddress = "Stråvalla 12",
                City = "Frillesås",
                AskingPrice = 600000,
                LivingArea = 35,
                SecondaryArea = 8,
                GardenArea = 1900,
                Description = "Det första fritidshuset.",
                NoOfRooms = 2,
                MonthlyFee = 0,
                YearlyRunningCosts = 9000,
                BuildYear = 1982,
                Error = false,
                BrokerId = "b58"
            }
        );
        builder.Entity<House>().HasData(
            new House
            {
                HouseId = 4,
                Category = Category.Bostadsrättsradhus,
                PostalAddress = "Drottninggatan 90",
                City = "Trollhättan",
                AskingPrice = 1200000,
                LivingArea = 140,
                SecondaryArea = 20,
                GardenArea = 20,
                Description = "Det första bostadsrättsradhuset.",
                NoOfRooms = 5,
                MonthlyFee = 5500,
                YearlyRunningCosts = 12000,
                BuildYear = 1989,
                Error = false,
                BrokerId = "b58"
            }
        );
    }
}
