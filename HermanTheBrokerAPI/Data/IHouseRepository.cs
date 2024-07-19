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
        //House GetAll;
        IEnumerable<House> GetAll();
    }
}
