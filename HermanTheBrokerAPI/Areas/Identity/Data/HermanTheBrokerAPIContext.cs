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
            .HasForeignKey(e => e.BrokerId)
            .HasPrincipalKey(e => e.Id);

        builder.Entity<Broker>().HasData(
            new Broker
            {
                Email = "c@a.com",
                Id = "a23",
                Name = "Dennis"
            }
            );
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
                 Id = "1",
                 HouseId = 1,
                 Street = "Storgatan",
                 City = "Vänersborg",
                 Area = 200,
                 BuildYear = 1984,
                 NoOfFloors = 2,
                 NoOfRooms = 7,
                 Category = Category.Villa,
                 BrokerId = "a23",
             }
            );
        builder.Entity<House>().HasData(
            new House
            {
                Id = "2",
                HouseId = 2,
                Street = "Drottninggatan",
                City = "Trollhättan",
                Area = 123,
                BuildYear = 1999,
                NoOfFloors = 1,
                NoOfRooms = 4,
                BrokerId = "a23"
            }
        );
        builder.Entity<House>().HasData(
            new House
            {
                Id = "3",
                HouseId = 3,
                Street = "Kungsgatan",
                City = "Uddevalla",
                Area = 80,
                BuildYear = 1909,
                NoOfFloors = 1,
                NoOfRooms = 2,
                BrokerId = "b58"
            }
        );
        builder.Entity<House>().HasData(
            new House
            {
                Id = "4",
                HouseId = 4,
                Street = "Odinsgatan",
                City = "Grästorp",
                Area = 275,
                BuildYear = 2011,
                NoOfFloors = 3,
                NoOfRooms = 8,
                BrokerId = "b58"
            }
        );
    }
}
