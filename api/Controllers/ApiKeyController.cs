using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using api.Contexts;
using api.Models;
using System.Security.Principal;
using System.Security.Cryptography;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ApiKeyController : ControllerBase
    {
        private readonly ILogger<ApiKeyController> _logger;
        private readonly OctopusContext _context;

        public ApiKeyController(ILogger<ApiKeyController> logger)
        {
            _logger = logger;
            _context = new OctopusContext();
        }

        // GET api/<ApiKeyController>
        [HttpGet]
        public IEnumerable<ApiKey> Get()
        {
            _logger.LogInformation("GET: api/ApiKey");
            try
            {
                return _context.ApiKeys.ToList();
            }
            catch (Exception)
            {
                throw new Exception($"tried to GET ALL but failed");
            }

        }

        // GET api/<ApiKeyController>/5
        [HttpGet("{userId}")]
        public IEnumerable<ApiKey> Get(int userId)
        {
            _logger.LogInformation("GET: api/ApiKey/#");
            try
            {
                return _context.ApiKeys.Where(a => a.UserId == userId);
            }
            catch (Exception)
            {
                throw new Exception($"tried to GET {userId} but failed");
            }

        }

        // POST api/<ApiKeyController>/5
        [HttpPost("{userId}")]
        public IEnumerable<ApiKey> Post(int userId)
        {
            _logger.LogInformation("POST: api/ApiKey/#");
            
            try
            {
                // find current api key and delete it
                ApiKey? ak = _context.ApiKeys.Where(a => a.UserId == userId).FirstOrDefault();
                if (ak != null)
                {
                    _context.ApiKeys.Remove(ak);
                    _context.SaveChanges();
                }
                
                // set up new key, attach userId and activate
                var randomGenerator = new Random();
                ApiKey new_ak = new ApiKey { UserId = userId, Key = randomGenerator.Next(1, 500000).ToString(), CreatedOn = DateTime.Now };
                _context.ApiKeys.Add(new_ak);
                _context.SaveChanges();
                return new List<ApiKey>() { new_ak };
            }
            catch (Exception)
            {
                throw new Exception($"tried to UPDATE WHERE UserId == {userId}, but id didn't exist");
            }
        }
    }
}
