using api.Contexts;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace api.Controllers
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly OctopusContext _context;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            _context = new OctopusContext();
        }

        // POST api/<LoginController>
        [HttpPost]
        public string Post([FromBody] User creds)
        {
            _logger.LogInformation("POST: api/Login");
            try
            {
                var user = _context.Accounts.FirstOrDefault(a => a.Username == creds.Username && a.Password == creds.Password);
                if(user != null)
                {
                    return "successful";
                }
                return "failed";

            }
            catch(Exception)
            {
                throw new Exception($"login failed");
            }
        }
    }
}
