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
        public IEnumerable<IdentityUser> GetById(string id)
        {
            var broker = context.Users.First(i => i.Id == id);
            IEnumerable<IdentityUser> result = new List<IdentityUser>();
            return result;
        }
        public bool Login()
        {
            return false;
        }
        //  "email": "oatrik@paheco.nu",
        // "password": "String1234<"
    }
}