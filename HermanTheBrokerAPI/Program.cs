using HermanTheBrokerAPI.Data;
using HermanTheBrokerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("HermanTheBrokerAPIContextConnection") ?? throw new InvalidOperationException("Connection string 'HermanTheBrokerAPIContextConnection' not found.");

// Add services to the container.
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ResidencesContext>();

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ResidencesContext>(options => options.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HermanTheBroker_API; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False"));

//builder.Services.AddDefaultIdentity<HermanTheBrokerAPIUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<HermanTheBrokerAPIContext>();
builder.Services.AddTransient<IBrokerRepository, BrokerRepository>();
builder.Services.AddTransient<IHouseRepository, HouseRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapIdentityApi<IdentityUser>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseAuthorization();
}

app.UseHttpsRedirection();

app.MapSwagger().RequireAuthorization();

app.MapControllers();

app.MapGet("/secret", (ClaimsPrincipal user) => $"Hello {user.Identity?.Name}. My secret")
    .RequireAuthorization();

app.Run();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ResidencesContext>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
}
public partial class Program { }