using Microsoft.AspNetCore.Mvc;
//using domain;
using data_access.MSSql;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private MSSql _db;
        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
            _db = new MSSql();
        }

        // GET: api/<AccountController>
        [HttpGet]
        public string Get()
        {
            try
            {
                return _db.selectAccounts();
            }
            catch (Exception e)
            {
                //throw new Exception("couldn't connect to database");
                return "exception";
            }
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
