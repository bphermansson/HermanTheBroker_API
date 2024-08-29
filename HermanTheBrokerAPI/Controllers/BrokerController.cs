using HermanTheBrokerAPI.Data;
using HermanTheBrokerAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet("GetAllBrokers")]
        [Authorize]
        public IActionResult GetAllBrokers()
        {
            try
            {
                IEnumerable<Broker> brokers = brokerRepository.GetAllBrokers();
                string jsonData = JsonConvert.SerializeObject(brokers, Formatting.Indented, new JsonSerializerSettings
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
        
        [HttpGet("GetBrokerByEmail")]
        [Authorize]
        public IActionResult GetBrokerByEmail(string brokerEmail)
        {
            try
            {
                IEnumerable<Broker> brokers = brokerRepository.GetBrokerByEmail(brokerEmail);
                string jsonData = JsonConvert.SerializeObject(brokers, Formatting.Indented, new JsonSerializerSettings
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

        [HttpGet("GetHousesByBrokerEmail")]
        [Authorize]
        public IActionResult GetHousesByBrokerEmail(string brokerEmail)
        {
            try
            {
                IEnumerable<House> brokersHouses = brokerRepository.GetHousesByBrokerEmail(brokerEmail);
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
        [Authorize]
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
        [Authorize]
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
