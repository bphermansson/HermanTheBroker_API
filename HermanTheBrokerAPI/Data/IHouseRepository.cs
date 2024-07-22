using HermanTheBrokerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermanTheBrokerAPI.Data
{
    public interface IHouseRepository
    {
        IEnumerable<House> Search(string? searchword);
        IEnumerable<House> GetAll();
        IEnumerable<House> GetById(int id);
    }
}
