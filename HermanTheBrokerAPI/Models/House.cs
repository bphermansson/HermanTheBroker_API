using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermanTheBrokerAPI.Models
{
	public enum Category
    {
		Bostadsrättslägenhet,
        Bostadsrättsradhus,
        Villa,
        Fritidshus
    }
    public class House
	{
		public int HouseId { get; set; }
        public string Street { get; set; }
		public string City { get; set; }
		public int Area { get; set; }
		public int BuildYear { get; set; }
        public int NoOfFloors { get; set; }
        public int NoOfRooms { get; set; }
        public Category? Category { get; set; }
        public int BrokerId { get; set; }
        public Broker Broker { get; set; }


    }
}
