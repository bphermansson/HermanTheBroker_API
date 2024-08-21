using HermanTheBrokerAPI.Models;
using HermanTheBrokerAPI.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Xml;
using HermanTheBrokerAPI.Areas.Identity.Data;

namespace HermanTheBrokerAPI.Data
{
    public class HouseRepository : IHouseRepository
    {
        private HermanTheBrokerAPIContext context;
        public HouseRepository(HermanTheBrokerAPIContext context)
        {
            this.context = context;
        }
        public IEnumerable<House> GetAll()
        {
            var houses = context.House
            //.Include(house => house.Broker)
            .ToList();
            return houses;
        }
        public IEnumerable<House> Search(Searchobject searchobject)
        {
            if (searchobject.Minsize > 0)
            {
                var house = context.House
               .Where(s => s.Area > searchobject.Minsize)
               .ToList();
                return house;
            }
            else if (searchobject.Maxsize > 0)
            {
                var house = context.House
               .Where(s => s.Area < searchobject.Maxsize)
               .ToList();
                return house;
            }
            else if (searchobject.Minsize > 0 && searchobject.Maxsize > 0)
            {
                var house = context.House
               .Where(s => s.Area > searchobject.Maxsize
               && s.Area < searchobject.Maxsize)
               .ToList();
                return house;
            }
            else if (searchobject.NoOfRooms > 0)
            {
                return context.House
                 .Where(s => s.NoOfRooms == searchobject.NoOfRooms)
                 .ToList();
            }
            else if (searchobject.City.Length != 0)
            {
                return context.House
                 .Where(s => s.City == searchobject.City)
                 .ToList();
            }
            return null;
        }
        public House GetById(string id)
        {
            var house = context.House.First(i => i.Id == id);
            return house;
        }
        //public async Task<IActionResult> NewHouse(House house)
        //{
        //    context.House.Add(house);
        //    await context.SaveChangesAsync();
        //    return null;
        //}
        public void NewHouse(House house)
        {
            context.Entry(house).State = EntityState.Modified;
            //bool hasChanges = context.ChangeTracker.HasChanges();
            context.House.Add(house);
            context.SaveChanges();
           // return null;
        }
        public async Task<IActionResult> EditHouse(House house)
        {
            //context.Entry(house).State = EntityState.Modified;
            //bool hasChanges = context.ChangeTracker.HasChanges();
            context.Entry(house).State = EntityState.Modified;
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return null;
        }
        public async Task<IActionResult> RemoveHouse(House house)
        {
            context.House.Remove(house);
            context.SaveChanges();
            return null;
        }
    }
}
