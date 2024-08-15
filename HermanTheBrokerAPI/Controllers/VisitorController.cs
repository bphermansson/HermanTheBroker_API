using HermanTheBrokerAPI.Data;
using HermanTheBrokerAPI.Classes;
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
        // GET: /api/Visitor/Search/{minsize}/{maxsize}/{city}/{category}
        [HttpGet("minsize_maxsize{minsize}/{maxsize}")]
        [HttpGet("city/{city}")]
        [HttpGet("category/{category}")]

        public async Task<IActionResult> HouseSearch(int? minsize=0, int? maxsize=0, string? city="", string? category="")
        {
            var route = Request.Path.Value.Split("/");
            if (route[3].ToString() == "minsize")
            {
                if (minsize == null)
                {
                    minsize = 0;
                }

            }


            if (maxsize == null)
            {
                maxsize = 1000;
            }
            if (city == null)
            {
                city = string.Empty;
            }
            if (category == null)
            {
                category = string.Empty;
            }
            var Searchstring = new Searchobject
            { Minsize = minsize, Maxsize = maxsize, City = city, Category = category };   

            IEnumerable<Models.House> house = houseRepository.Search(Searchstring);
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
            Models.House house = houseRepository.GetById(id);
            string jsonData = JsonConvert.SerializeObject(house);
            return Content(jsonData, "application/json");
        }
    }
    }

// hermansson.patrik2@gmail.com
// stringABC123-