using HermanTheBrokerAPI.Data;
using HermanTheBrokerAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HermanTheBrokerAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BrokerController : ControllerBase
    {
        private readonly Broker _context;
        private IBrokerRepository brokerRepository;
        public BrokerController(IBrokerRepository brokerRepository)
        {
            this.brokerRepository = brokerRepository;
        }

        [HttpGet("{email}")]
                public IActionResult GetBrokerByEmail(string email)
        {
            Broker broker = brokerRepository.GetBrokerByEmail(email);
            string jsonData = JsonConvert.SerializeObject(broker);
            return Content(jsonData, "application/json");
        }
        
        [HttpGet("GetHousesByBrokerEmail")]
        //[Authorize]
        public IActionResult GetHousesByBrokerEmail(string email)
        {
            try
            {
                IEnumerable<House> brokersHouses = brokerRepository.GetHousesByBrokerEmail(email);
                string jsonData = JsonConvert.SerializeObject(brokersHouses, Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return Content(jsonData, "application/json");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // Couldnt get put to work...
        // [HttpPut("EditBroker")]
        [HttpPost("EditBroker")]
        public ActionResult EditBroker(Broker uid)
        {
            try
            {
                brokerRepository.EditBroker(uid);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        // Not used
        [HttpDelete("RemoveBroker")]
        public ActionResult RemoveBroker(Broker uid)
        {
            try
            {
                brokerRepository.RemoveBroker(uid);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
