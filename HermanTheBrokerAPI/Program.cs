using HermanTheBrokerAPI.Data;
using HermanTheBrokerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HermanTheBrokerAPI;
using System.Security.Claims;
using Microsoft.AspNetCore.HttpLogging;
using Nist.Errors;
using System.Net;
using HermanTheBrokerAPI.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddProblemDetails();

builder.Services.AddDbContext<HermanTheBrokerAPIContext>(options => options.UseSqlServer
("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HermanTheBroker_API; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False"));
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
builder.Services.AddIdentityApiEndpoints<Broker>()
    .AddEntityFrameworkStores<HermanTheBrokerAPIContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseExceptionHandler();
app.UseStatusCodePages();

app.MapSwagger().RequireAuthorization();

app.MapControllers();

// Identity
app.MapGroup("/identity").MapIdentityApi<Broker>();

// For testing
// app.MapGet("/requires-auth", (ClaimsPrincipal user) => $"Hello, {user.Identity?.Name}!").RequireAuthorization();
app.UseHttpLogging();
app.UseErrorBody<Error>(ex => ex switch {
    NotEnoughLevelException _ => new(HttpStatusCode.BadRequest, "NotEnoughLevel"),
    _ => new(HttpStatusCode.InternalServerError, "Unknown")
}, showException: false);
app.Run();

public partial class Program { }
public class NotEnoughLevelException : Exception;
