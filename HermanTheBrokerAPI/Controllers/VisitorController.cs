using HermanTheBrokerAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using FribergsCarRentals.DataAccess.Data;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HermanTheBrokerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : Controller
    {
        //private readonly ResidencesContext _context;

        //public VisitorController(ResidencesContext context)
        //{
        //    _context = context;
        //}

        private IHouseRepository houseRepository;
        public VisitorController(IHouseRepository houseRepository)
        {
            this.houseRepository = houseRepository;
        }
        //HouseSearch
        // GET: /api/Visitor/Search/{searchstring}
        [HttpGet("{searchstring}")]
        public async Task<IActionResult> HouseSearch(string searchstring)
        {
            IEnumerable<Models.House> house = houseRepository.Search(searchstring);
            string jsonData = JsonConvert.SerializeObject(house);
            return Content(jsonData, "application/json");
        }
        //HouseSearch
        // GET: /api/Visitor/Search/{searchstring}
        //[HttpGet("{searchstring}")]
        //public async Task<IActionResult> HouseSearch(string searchstring)
        //{
        //    var book = _context.House
        //    .Where(s => s.Street.Contains(searchstring) || s.Street.Contains(searchstring))
        //    .ToList();

        //    var houses = _context.House
        //        .Where(s => s.HouseId == Int32.Parse(searchstring)
        //        || s.Street.Contains(searchstring)
        //        || s.City.Contains(searchstring)
        //        || s.Area == Int32.Parse(searchstring)
        //        || s.BuildYear == Int32.Parse(searchstring)
        //        || s.NoOfFloors == Int32.Parse(searchstring)
        //        || s.NoOfRooms == Int32.Parse(searchstring)
        //        )
        //        .ToString().ToList();
        //        if (houses == null)
        //        {
        //            return NotFound();
        //        }
        //        string jsonData = JsonConvert.SerializeObject(houses);
        //        return Content(jsonData, "application/json");
        //    }

        //HouseDetails
        // GET: /api/Visitor/Details/{houseId}

        //{
        //return new string[] { "value1", "value2" };
        //}
        //AllHouses
        // GET: /api/Visitor/Houses
        //[HttpGet("Visitor/Houses")]
        //public async Task<IActionResult> Houses()
        //{
        //    string jsonData = JsonConvert.SerializeObject(await _context.House.ToListAsync());
        //    return Content(jsonData, "application/json");
        //}
        [HttpGet("Houses")]
        [Authorize]
        public IActionResult Houses()
        {
            IEnumerable<Models.House> house = houseRepository.GetAll();
            string jsonData = JsonConvert.SerializeObject(house);
            return Content(jsonData, "application/json");
        }
        [HttpGet("HouseById")]
        public IActionResult GetHouseById(int id)
        {
            IEnumerable<Models.House> house = houseRepository.GetById(id);
            string jsonData = JsonConvert.SerializeObject(house);
            return Content(jsonData, "application/json");
        }
    }
    }

