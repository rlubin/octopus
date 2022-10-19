using api.Contexts;
using api.Controllers;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Threading.Tasks;

namespace api.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string APIKEYNAME = "ApiKey";
        private readonly ILogger<AccountController> _logger;
        private OctopusContext _context;

        public ApiKeyMiddleware(RequestDelegate next, ILogger<AccountController> logger)
        {
            _next = next;
            _logger = logger;
            _context = new OctopusContext();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                _context.ApiCalls.Add(new ApiCall { Endpoint = context.Request.Method + context.Request.Path, Key = "0", UserId = "0", IpAddress = context.Connection.RemoteIpAddress.ToString(), CalledOn = DateTime.Now });
                _context.SaveChanges();
                _logger.LogInformation("Api Key was not provided");
                await context.Response.WriteAsync("Api Key was not provided");
                return;
            }

            string exApiKey = extractedApiKey.ToString();
            ApiKey? a = _context.ApiKeys.Where(a => a.Key == exApiKey).First();

            if (a == null)
            {
                context.Response.StatusCode = 401;
                _context.ApiCalls.Add(new ApiCall { Endpoint = context.Request.Method + context.Request.Path, Key = exApiKey, UserId = a.UserId.ToString(), IpAddress = context.Connection.RemoteIpAddress.ToString(), CalledOn = DateTime.Now });
                _context.SaveChanges();
                _logger.LogInformation("Unauthorized client");
                await context.Response.WriteAsync("Unauthorized client");
                return;
            }

            _context.ApiCalls.Add(new ApiCall { Endpoint = context.Request.Method + context.Request.Path, Key = exApiKey, UserId = a.UserId.ToString(), IpAddress = context.Connection.RemoteIpAddress.ToString(), CalledOn = DateTime.Now });
            _context.SaveChanges();
            await _next(context);
        }
    }
}
