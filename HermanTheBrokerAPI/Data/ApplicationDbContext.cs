using HermanTheBrokerAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

// update-database 0
// remove-migration
// add-migration "Init"
// update-database

namespace HermanTheBrokerAPI.Data
{
    //public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    //{
    //    //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    //    //: base(options)
    //    //{
    //    //}

    //    public DbSet<Broker> Broker { get; set; }
    //    public DbSet<House> House { get; set; }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder);

    //        //modelBuilder.Entity<Broker>().HasData(new Broker { ID = 1, Name = "Jeff", PhoneNumber=456 });
    //        //modelBuilder.Entity<Broker>().HasData(new Broker { Name = "Kerry", ID = 2 });
    //        //modelBuilder.Entity<Broker>().HasData(new Broker { Name = "Tom", ID = 3 });
    //        //modelBuilder.Entity<Broker>().HasData(new Broker { Name = "Dave", ID = 4 });



        
    //    }
    //}
}
