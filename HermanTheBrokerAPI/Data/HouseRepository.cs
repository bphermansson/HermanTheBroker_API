using HermanTheBrokerAPI.Data;
using HermanTheBrokerAPI.Models;
using Microsoft.Build.Logging;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

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
            //.Include(house => house.BrokerId)
            .ToList();
            return houses;
        }
        public IEnumerable<House> Search(string? searchword)
        {
            var house = context.House
                .Where(s => s.Street.Contains(searchword) 
                || s.City.Contains(searchword)
                || s.Area.Equals(searchword)
                || s.BuildYear.Equals(searchword)
                || s.NoOfFloors.Equals(searchword)
                || s.NoOfRooms.Equals(searchword))
                .ToList();
            return house;
        }
        public IEnumerable<House> GetById(int id)
        {
            var house = context.House.First(i => i.HouseId == id);
            List<House> result = new List<House>();
            //result.Add(house);
            return result;
        }

    }

}
