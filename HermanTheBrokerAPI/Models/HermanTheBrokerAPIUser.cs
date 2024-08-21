using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HermanTheBrokerAPI.Models;

// Add profile data for application users by adding properties to the HermanTheBrokerAPIUser class
public class HermanTheBrokerAPIUser : IdentityUser
{
    public int Testprop { get; set; }
    public ICollection<House> Houses { get; set; }

}

