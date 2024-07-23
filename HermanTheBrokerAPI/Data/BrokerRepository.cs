using HermanTheBrokerAPI.Data;

namespace HermanTheBrokerAPI.Data
{
    public class BrokerRepository : IBrokerRepository
    {
        private ResidencesContext context;
        public BrokerRepository(ResidencesContext context)
        {
            this.context = context;
        }
    }
}