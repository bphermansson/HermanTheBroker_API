using HermanTheBrokerAPI.Data;
using HermanTheBrokerAPI.Models;
using IdentityTest;
using HermanTheBrokerAPI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace HermanTheBrokerAPI.Data
{
    public class BrokerRepository : IBrokerRepository
    {



        private ResidencesContext context;
        public BrokerRepository(ResidencesContext context)
        {
            this.context = context;
        }
        public IEnumerable<IdentityUser> GetAll()
        {
            IEnumerable<IdentityUser> users = context.Users.ToList();

            return users;
        }
    }
}