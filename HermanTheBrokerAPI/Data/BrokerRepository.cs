using HermanTheBrokerAPI.Data;
using HermanTheBrokerAPI.Models;
using IdentityTest;
using HermanTheBrokerAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace HermanTheBrokerAPI.Data
{
    public class BrokerRepository : IBrokerRepository
    {
        private ApplicationDbContext context;
        public BrokerRepository(ApplicationDbContext context)
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
            // var firstStudentAgain = db.Student
            // .Include(s => s.Grade)
            // .OrderBy(b => b.Id)
            // .First();
            // Console.WriteLine("Student 1:" + firstStudentAgain.Name);

            var broker = context.Users.First(i => i.Id == id);
            IEnumerable<IdentityUser> result = new List<IdentityUser>();
            return result;
        }
    }
}