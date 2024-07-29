using HermanTheBrokerAPI.Models;
using IdentityTest;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace HermanTheBrokerAPI.Data
{
    public class ResidencesContext : IdentityDbContext<IdentityUser>
    {
        public ResidencesContext() { }

        public ResidencesContext(DbContextOptions<ResidencesContext> options)
            : base(options)
        {
        }

        public DbSet<Broker> Broker { get; set; }
        public DbSet<House> House { get; set; }
        public DbSet<AspNetUsers> AspNetUsers { get; set; }

        //private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HermanTheBroker_API;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(connectionString);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Broker>().HasData(
            //    new Broker
            //    {
            //        BrokerId = 1,
            //        Name = "Patrik",
            //        PhoneNumber = 0708682666,
            //    }
            //);


            // ******** Categories *********

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "Bostadsrättslägenhet",
                }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 2,
                    Name = "Bostadsrättsradhus",
                }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 3,
                    Name = "Villa",
                }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 4,
                    Name = "Fritidshus",
                }
            );

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
                    CategoryId = 2
                    //Broker = new Broker
                    //{
                    //    BrokerId = 1,
                    //    Name = "Patrik",
                    //    PhoneNumber = 0,
                    //}
                }
            );


            //modelBuilder.Entity<Broker>().HasData(
            //    new Broker
            //    {
            //        BrokerId = 2,
            //        Name = "Marcus",
            //        PhoneNumber = 07012345678,
            //    }
            //);
            //modelBuilder.Entity<Broker>().HasData(
            //    new Broker
            //    {
            //        BrokerId = 3,
            //        Name = "Bo",
            //        PhoneNumber = 0708666705,
            //    }
            //);


            // ******** Houses *********

            modelBuilder.Entity<House>().HasData(
                new House
                {
                    HouseId = 2,
                    Street = "Drottninggatan",
                    City = "Trollhättan",
                    Area = 123,
                    BuildYear = 1999,
                    NoOfFloors = 1,
                    NoOfRooms = 4,
                    CategoryId = 1
                    //                    Broker = new Broker { BrokerId = 2 }
                }
            );
            modelBuilder.Entity<House>().HasData(
                new House
                {
                    HouseId = 3,
                    Street = "Kungsgatan",
                    City = "Uddevalla",
                    Area = 80,
                    BuildYear = 1909,
                    NoOfFloors = 1,
                    NoOfRooms = 2,
                    CategoryId = 4
                    //                    Broker = new Broker { BrokerId = 1 }
                }
            );
            modelBuilder.Entity<House>().HasData(
                new House
                {
                    HouseId = 4,
                    Street = "Odinsgatan",
                    City = "Grästorp",
                    Area = 275,
                    BuildYear = 2011,
                    NoOfFloors = 3,
                    NoOfRooms = 8,
                    CategoryId = 3
                    //                    Broker = new Broker { BrokerId = 3 }
                }
            );

        }
     }
}
