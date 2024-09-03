using Microsoft.AspNetCore.Identity;

namespace HermanTheBrokerAPI.Models
{
	public class Broker : IdentityUser
	{
		public string Name { get; set; } = string.Empty;
		public long PhoneNumber { get; set; }
		public ICollection<House>? Houses { get; set; } = null!;
    }
}
