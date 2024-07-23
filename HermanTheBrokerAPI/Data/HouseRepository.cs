using HermanTheBrokerAPI.Data;
using HermanTheBrokerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HermanTheBrokerAPI.Data
{
    public class HouseRepository : IHouseRepository
    {
        private ResidencesContext context;
        public HouseRepository(ResidencesContext context)
        {
            this.context = context;
        }
        public IEnumerable<House> GetAll()
        {
            return context.House.ToList();
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
            //House house = context.House
            //    .Where(s => s.HouseId.Equals(id));
            var house = context.House.First(i => i.HouseId == id);
            List<House> result = new List<House>();
            result.Add(house);
            return result;
        }

    }

}
