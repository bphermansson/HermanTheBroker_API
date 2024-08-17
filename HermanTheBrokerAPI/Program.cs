using HermanTheBrokerAPI.Data;
using HermanTheBrokerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HermanTheBrokerAPI.Areas.Identity.Data;
using IdentityTest;
using HermanTheBrokerAPI;
using System.Security.Claims;
using Microsoft.AspNetCore.HttpLogging;
using Nist.Errors;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddProblemDetails();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer
("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HermanTheBroker_API; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False"));
//builder.Services.AddTransient<IBrokerRepository, BrokerRepository>();
builder.Services.AddTransient<IHouseRepository, HouseRepository>();
builder.Services.AddTransient<IBrokerRepository, BrokerRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpLogging(o => { });


// Identity
// https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-4/#identity-api-endpoints
builder.Services.AddAuthorization();
builder.Services.AddSingleton(TimeProvider.System);
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseAuthorization();
}

app.UseHttpsRedirection();
app.UseExceptionHandler();
app.UseStatusCodePages();

app.MapSwagger().RequireAuthorization();

app.MapControllers();
app.MapIdentityApi<IdentityUser>();

// Identity
app.MapGroup("/identity").MapIdentityApi<IdentityUser>();

// For testing
app.MapGet("/requires-auth", (ClaimsPrincipal user) => $"Hello, {user.Identity?.Name}!").RequireAuthorization();
app.UseHttpLogging();
app.UseErrorBody<Error>(ex => ex switch {
    NotEnoughLevelException _ => new(HttpStatusCode.BadRequest, "NotEnoughLevel"),
    _ => new(HttpStatusCode.InternalServerError, "Unknown")
}, showException: false);
app.Run();

//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<ResidencesContext>();
//    dbContext.Database.EnsureDeleted();
//    dbContext.Database.EnsureCreated();
//}
public partial class Program { }
public class NotEnoughLevelException : Exception;
