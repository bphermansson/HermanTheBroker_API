using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermanTheBroker_API.Models
{
	public class Residence
	{
		[Key]
		public int Id { get; set; }
        public string CurrentOwner { get; set; }
        public string StreetName { get; set; }
		public string City { get; set; }
		public string PropertyDesignation { get; set; }
		public int ResidenceArea { get; set; }
		public int BuildYear { get; set; }

	}
}
