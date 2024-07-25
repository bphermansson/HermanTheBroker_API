using HermanTheBrokerAPI.Data;
using HermanTheBrokerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HermanTheBrokerAPI.Areas.Identity.Data;
using IdentityTest;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("HermanTheBrokerAPIContextConnection") ?? throw new InvalidOperationException("Connection string 'HermanTheBrokerAPIContextConnection' not found.");
builder.Services.AddDbContext<ResidencesContext>(options => options.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HermanTheBroker_API; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False"));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ResidencesContext>();

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ResidencesContext>();

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IHouseRepository, HouseRepository>();
builder.Services.AddTransient<IBrokerRepository, BrokerRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapIdentityApi<IdentityUser>();

app.UseAuthorization();

app.MapControllers();

app.Run();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ResidencesContext>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
}
public partial class Program { }