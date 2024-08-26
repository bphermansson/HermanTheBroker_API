using HermanTheBrokerAPI.Areas.Identity.Data;
using HermanTheBrokerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HermanTheBrokerAPI.Data
{
    public class BrokerRepository : IBrokerRepository
    {
        private HermanTheBrokerAPIContext context;
        public BrokerRepository(HermanTheBrokerAPIContext context)
        {
            this.context = context;
        }
        public IEnumerable<Broker> GetAll()
        {
            IEnumerable<Broker> users = context.Users.ToList();

            return users;
        }
        public Broker GetBrokerByEmail(string email)
        {
            var broker = context.Users.First(i => i.Email == email);
            return broker;
        }
        public async Task<IActionResult> EditBroker(Broker uid)
        {
            context.Entry(uid).State = EntityState.Modified;
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                entry.OriginalValues.SetValues(entry.GetDatabaseValues());
            }
            return null;
        }
        public IEnumerable<House> GetHousesByBrokerId(string id)
        {
            return context.House
             .Include(broker => broker.Broker)
             .Where(s => s.HouseId == id)
             .ToList();
        }

        // This we dont need...
        public async Task<bool> RemoveBroker(Broker uid)
        {
            try
            {
                context.Users.Remove(uid);
                context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                return false;
            }
        }
    }
}