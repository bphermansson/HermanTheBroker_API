using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HermanTheBrokerAPI.Models;

namespace HermanTheBrokerAPI.Data;

public class HermanTheBrokerAPIContext : IdentityDbContext<HermanTheBrokerAPIUser>
{
    public HermanTheBrokerAPIContext(DbContextOptions<HermanTheBrokerAPIContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
