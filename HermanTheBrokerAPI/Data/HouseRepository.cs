using HermanTheBrokerAPI.Models;
using HermanTheBrokerAPI.Classes;
using Microsoft.EntityFrameworkCore;

namespace HermanTheBrokerAPI.Data
{
    public class HouseRepository : IHouseRepository
    {
        private ApplicationDbContext context;
        public HouseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<House> GetAll()
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
            else if (searchobject.City.Length!=0)
            {
                return context.House
                 .Where(s => s.City == searchobject.City)
                 .ToList();
            }
            return null;
        }
        public House GetById(int id)
        {
            var house = context.House.First(i => i.HouseId == id);
            return house;
        }
    }
}
