using HermanTheBrokerAPI.Models;
using IdentityTest;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermanTheBrokerAPI.Data
{
    public interface IBrokerRepository
    {
        public IEnumerable<IdentityUser> GetAll();

    }
}
