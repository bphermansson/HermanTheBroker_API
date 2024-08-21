using HermanTheBrokerAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System;

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
        public IdentityUser GetBrokerByEmail(string email)
        {
            // var firstStudentAgain = db.Student
            // .Include(s => s.Grade)
            // .OrderBy(b => b.Id)
            // .First();
            // Console.WriteLine("Student 1:" + firstStudentAgain.Name);
            // id = "230b643b-4b52-43a3-931c-f9ca0e0a04f2";

            var broker = context.Users.First(i => i.Email == email);
           // IEnumerable<IdentityUser> result = new List<IdentityUser>();
            return broker;
        }
        public async Task<IActionResult> EditBroker(HermanTheBrokerAPIUser uid)
        {
            context.Entry(uid).State = EntityState.Modified;
            //bool hasChanges = context.ChangeTracker.HasChanges();
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

        // This we dont need...
        public async Task<bool> RemoveBroker(HermanTheBrokerAPIUser uid)
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