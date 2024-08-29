using HermanTheBrokerAPI.Models;
using HermanTheBrokerAPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HermanTheBrokerAPI.Data
{
    public interface IHouseRepository
    {
        IEnumerable<House> Search(Searchobject searchstring);
        IEnumerable<House> GetAllHouses();
        public House GetById(int id);
        void NewHouse(House house);
        Task<ActionResult<bool>> EditHouse(House house);
        public Task<ActionResult<bool>> RemoveHouse(int id);
    }
}
