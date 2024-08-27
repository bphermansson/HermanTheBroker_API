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
        public IEnumerable<Broker> GetBrokerByEmail(string brokerEmail)
        {
            //var broker = context.Users
            //    .First(i => i.Email == email);
            //return broker;

            return context.Broker
                .Include(broker => broker.Houses)
                .Where(broker => broker.Email == brokerEmail)
                .ToList();
        }
        public async Task<ActionResult<bool>> EditBroker(Broker uid)
        {
            context.Entry(uid).State = EntityState.Modified;
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return false;

            }
        }
        public IEnumerable<House> GetHousesByBrokerEmail(string brokerEmail)
        {
            return context.House
             .Include(broker => broker.Broker)
             .Include(house => house.Broker)
             .Where(s => s.Broker.Email == brokerEmail)
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