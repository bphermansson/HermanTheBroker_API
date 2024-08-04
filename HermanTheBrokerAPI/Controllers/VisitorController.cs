using HermanTheBrokerAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HermanTheBrokerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : Controller
    {
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

        [HttpGet("Houses")]
        //[Authorize]
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

