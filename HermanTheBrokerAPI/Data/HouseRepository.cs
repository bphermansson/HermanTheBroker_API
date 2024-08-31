using HermanTheBrokerAPI.Models;
using HermanTheBrokerAPI.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HermanTheBrokerAPI.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HermanTheBrokerAPI.Data
{
    public class HouseRepository : IHouseRepository
    {
        private HermanTheBrokerAPIContext context;
        public HouseRepository(HermanTheBrokerAPIContext context)
        {
            this.context = context;
        }
        public IEnumerable<House> GetAllHouses()
        {
            var houses = context.House
            .Include(house => house.Broker)
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
        public House GetById(int id)
        {
            var res = context.House
                .Include(broker => broker.Broker)
                .Where(idd => idd.HouseId == id)
                .ToList();
            return res.FirstOrDefault();
        }
        public void NewHouse(House house)
        {
            context.Entry(house).State = EntityState.Modified;
            bool hasChanges = context.ChangeTracker.HasChanges();
            context.House.Add(house);
            context.SaveChanges();
        }
        public async Task<ActionResult<bool>> EditHouse(House house)
        {
            context.Entry(house).State = EntityState.Modified;
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
        public async Task<ActionResult<bool>> RemoveHouse(int id)
        {
            House houseToRemove = GetById(id);
            context.House.Remove(houseToRemove);
            context.SaveChanges();
            try
            {
                context.House.Remove(houseToRemove);
                context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
    }
}
