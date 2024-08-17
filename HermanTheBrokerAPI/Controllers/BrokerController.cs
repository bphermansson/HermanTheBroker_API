using HermanTheBrokerAPI.Data;
using HermanTheBrokerAPI.Models;
using IdentityTest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HermanTheBrokerAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BrokerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IBrokerRepository brokerRepository;
        public BrokerController(IBrokerRepository brokerRepository)
        {
            this.brokerRepository = brokerRepository;
        }

        //BrokerDetails
        // GET: /api/Broker/{brokerid}
        [HttpGet("{brokerid}")]
        public IEnumerable<string> Get(int brokerid)
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("Brokers")]
        //[Authorize]
        public IActionResult Brokers()
        {
            IEnumerable<IdentityUser> broker = brokerRepository.GetAll();
            string jsonData = JsonConvert.SerializeObject(broker);
            return Content(jsonData, "application/json");
        }
    }
}
