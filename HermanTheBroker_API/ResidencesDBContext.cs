using HermanTheBroker_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermanTheBroker_API
{
	public class ResidencesDBContext : DbContext
	{
		public DbSet<Broker> Broker { get; set; }
		public DbSet<Residence> Residence { get; set; }
		private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HermanTheBroker_API;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(connectionString);
		}
	}
}
