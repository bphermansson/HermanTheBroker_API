using HermanTheBrokerAPI.Data;
using HermanTheBrokerAPI.Models;

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
    }

}
