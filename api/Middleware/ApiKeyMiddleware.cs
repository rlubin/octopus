using api.Contexts;
using api.Controllers;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            _logger.LogInformation("ApiKey check");
            //if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                _logger.LogInformation("Api Key was not provided");
                await context.Response.WriteAsync("Api Key was not provided");
                return;
            }

            //var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            //var apiKey = appSettings.GetValue<string>(APIKEYNAME);

            //if (!apiKey.Equals(extractedApiKey))
            //{
            //    context.Response.StatusCode = 401;
            //    _logger.LogInformation("Unauthorized client");
            //    await context.Response.WriteAsync("Unauthorized client");
            //    return;
            //}

            string exApiKey = extractedApiKey.ToString();
            Account? a = _context.Accounts.Where(a => a.ApiKey == exApiKey).First();
            _logger.LogError(a.ApiKey + "-" + exApiKey);

            if (a == null)
            {
                context.Response.StatusCode = 401;
                _logger.LogInformation("Unauthorized client");
                await context.Response.WriteAsync("Unauthorized client");
                return;
            }

            _logger.LogInformation("ApiKey check successful");
            await _next(context);
        }
    }
}
