using Microsoft.AspNetCore.Mvc;
//using domain;
using data_access.Data;
using data_access.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        OctopusContext _context;
        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
            _context = new OctopusContext();
        }

        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            var accounts = _context.Accounts;

            foreach (Account a in accounts)
            {
                Console.WriteLine(a.UserId);
                Console.WriteLine(a.Email);
                Console.WriteLine(a.Username);
                Console.WriteLine(a.Password);
            }

            return accounts.ToList();
            //return Content(accounts.FirstOrDefault().UserId + accounts.FirstOrDefault().Email + accounts.FirstOrDefault().Username + accounts.FirstOrDefault().Password);
            
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
