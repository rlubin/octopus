using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private OctopusContext _context;
        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
            _context = new OctopusContext();
        }

        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return _context.Accounts.ToList();
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public IEnumerable<Account> Get(int id)
        {
            return _context.Accounts.Where(a => a.UserId == id).ToList();
        }

        // POST api/<AccountController>
        [HttpPost]
        public void Post([FromBody] Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Account account)
        {
            Account? a = _context.Accounts.Where(a => a.UserId == id).FirstOrDefault();
            a.Username = account.Username;
            a.Email = account.Email;
            a.Password = account.Password;
            _context.Accounts.Update(a);
            _context.SaveChanges();
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Account? a = _context.Accounts.Where(a => a.UserId == id).FirstOrDefault();
            _context.Accounts.Remove(a);
            _context.SaveChanges();
        }
    }
}
