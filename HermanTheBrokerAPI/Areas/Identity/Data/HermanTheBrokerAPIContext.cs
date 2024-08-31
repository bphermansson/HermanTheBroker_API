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
                // Password asdf1234_K
                Id = "6dbbc953-5718-404f-b6c4-00b2341a7051",
                Name = "Göran",
                UserName = "admin@hermanthebroker.se",
                NormalizedUserName = "ADMIN@HERMANTHEBROKER.COM",
                Email = "admin@hermanthebroker.se",
                NormalizedEmail = "ADMIN@HERMANTHEBROKER.COM",
                PasswordHash = "AQAAAAIAAYagAAAAEFx5utr9Pi8EeehOpXq9kjeme5/5JPS0EzDdcsaQ4r6laZ1pW+M2DgSfw4HiUxYQbQ==",
                SecurityStamp = "KSOKRWVRJPN7H4B7AKRRAHX4JME3GZNL",
                ConcurrencyStamp = "241e7992-c1bd-4a3a-911a-c700caadb262",
                LockoutEnabled = true,
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
                 HouseId = 1,
                 Street = "Storgatan",
                 City = "Vänersborg",
                 Area = 200,
                 BuildYear = 1984,
                 NoOfFloors = 2,
                 NoOfRooms = 7,
                 Category = Category.Villa,
                 //BrokerId = "b58"
             }
            );
        builder.Entity<House>().HasData(
            new House
            {
                HouseId = 2,
                Street = "Drottninggatan",
                City = "Trollhättan",
                Area = 123,
                BuildYear = 1999,
                NoOfFloors = 1,
                NoOfRooms = 4,
                //BrokerId = "b58"
            }
        );
        builder.Entity<House>().HasData(
            new House
            {
                HouseId = 3,
                Street = "Kungsgatan",
                City = "Uddevalla",
                Area = 80,
                BuildYear = 1909,
                NoOfFloors = 1,
                NoOfRooms = 2,
                //BrokerId = "a23"
            }
        );
        builder.Entity<House>().HasData(
            new House
            {
                HouseId = 4,
                Street = "Odinsgatan",
                City = "Grästorp",
                Area = 275,
                BuildYear = 2011,
                NoOfFloors = 3,
                NoOfRooms = 8,
                //BrokerId = "a23"
            }
        );
    }
}
