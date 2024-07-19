using HermanTheBrokerAPI.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HermanTheBrokerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrokerController : ControllerBase
    {
        private readonly ResidencesContext _context;

        public BrokerController(ResidencesContext context)
        {
            _context = context;
        }
        //BrokerDetails
        // GET: /api/Visitor/{brokerid}
        [HttpGet("{brokerid}")]
        public IEnumerable<string> Get(int brokerid)
        {
            return new string[] { "value1", "value2" };
        }

    }
}
