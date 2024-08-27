using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace HermanTheBrokerAPI.Models
{
	public class Broker : IdentityUser
	{
		public string Name { get; set; } = string.Empty;
		public long PhoneNumber { get; set; }
		public ICollection<House> Houses { get; set; }
	}
}
