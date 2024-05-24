using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace HermanTheBroker_API.Models
{
	public class Broker
	{
		[Key]
		public int Id { get; set; }
        public string Name { get; set; }
		public string PhoneNumber { get; set; }
		public virtual List<Residence> Residences { get; set; }

	}
}
