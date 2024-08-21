using HermanTheBrokerAPI.Data;
using HermanTheBrokerAPI.Classes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using HermanTheBrokerAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HermanTheBrokerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : Controller
    {
        private IHouseRepository houseRepository;
        public HouseController(IHouseRepository houseRepository)
        {
            this.houseRepository = houseRepository;
        }

        //HouseSearch
        // GET: /api/Visitor/Search/{minsize}/{maxsize}/{city}/{noofrooms}
        [HttpGet("Search/{minsize}/{maxsize}/{city}/{noofrooms}")]
        [HttpGet("minsize{minsize}")]
        [HttpGet("maxsize{maxsize}")]
        [HttpGet("minsize_maxsize{minsize}/{maxsize}")]
        [HttpGet("noofrooms/{noofrooms}")]
        [HttpGet("city/{city}")]

        public async Task<IActionResult> HouseSearch(int? minsize = 0, int? maxsize = 0, string? city = "", int? noofrooms = 0)
        {
            if (minsize == null)
            {
                minsize = 0;
            }
            if (maxsize == null)
            {
                maxsize = 1000;
            }
            if (noofrooms == null)
            {
                noofrooms = 0;
            }
            //if (city == null)
            //{
            //    city = string.Empty;
            //}
            var Searchstring = new Searchobject
            { Minsize = minsize, Maxsize = maxsize, NoOfRooms = noofrooms, City = city };

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
        [HttpPost("NewHouse")]
        public ActionResult NewHouse(House house)
        {
            try
            {
                houseRepository.NewHouse(house);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPost("EditHouse")]
        public ActionResult EditHouse(House house)
        {
            try
            {
                houseRepository.EditHouse(house);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPost("RemoveHouse")]
        public ActionResult RemoveHouse(House house)
        {
            try
            {
                houseRepository.RemoveHouse(house);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}