using Microsoft.AspNetCore.Mvc;
using api.Contexts;
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
            _logger.LogInformation("GET: api/Account");
            try
            {
                return _context.Accounts.ToList();
            }
            catch (Exception)
            {
                throw new Exception("tried to GET ALL but failed");
            }
            
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public IEnumerable<Account> Get(int id)
        {
            _logger.LogInformation("GET: api/Account/#");
            try
            {
                return _context.Accounts.Where(a => a.UserId == id).ToList();
            }
            catch (Exception)
            {
                throw new Exception($"tried to GET {id} but failed");
            }
            
        }

        // POST api/<AccountController>
        [HttpPost]
        public string Post([FromBody] Account account)
        {
            _logger.LogInformation("POST: api/Account");
            try
            {
                _context.Accounts.Add(account);
                _context.SaveChanges();
                return "account added to db";
            }
            catch (Exception)
            {
                throw new Exception("tried to INSERT but failed");
            }
            
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Account account)
        {
            _logger.LogInformation("PUT: api/Account/#");
            Account? a = _context.Accounts.Where(a => a.UserId == id).FirstOrDefault();
            try
            {
                a.Username = account.Username;
                a.Email = account.Email;
                a.Password = account.Password;
                //a.ApiKey = account.ApiKey;
                _context.Accounts.Update(a);
                _context.SaveChanges();
                return $"userId == {a.UserId} updated in db";
            }
            catch (Exception)
            {
                throw new Exception ($"tried to UPDATE WHERE UserId == {id}, but id didn't exist");
            }
            
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _logger.LogInformation("DELETE: api/Account/#");
            Account? a = _context.Accounts.Where(a => a.UserId == id).FirstOrDefault();
            try
            {
                _context.Accounts.Remove(a);
                _context.SaveChanges();
                return $"userId == {a.UserId} removed from db";
            }
            catch (Exception)
            {
                throw new Exception($"tried to DELETE WHERE UserId == {id}, but id didn't exist");
            }
            
        }
    }
}
