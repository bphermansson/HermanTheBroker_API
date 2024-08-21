﻿using HermanTheBrokerAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public IdentityUser GetBrokerByEmail(string email);
        public Task<IActionResult> EditBroker(Broker uid);
        public Task<bool> RemoveBroker(Broker uid);

    }
}
