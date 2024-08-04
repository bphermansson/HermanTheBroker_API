﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace HermanTheBrokerAPI.Models
{
	public class Broker
	{
		public int ID { get; set; }
        public string Name { get; set; }
		public long PhoneNumber { get; set; }
		public virtual ICollection<House> House { get; set; }
	}
}
