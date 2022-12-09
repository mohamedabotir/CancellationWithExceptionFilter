using Microsoft.AspNetCore.Mvc;

namespace CancellationWithExceptionFilter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [Produces("application/json")]
        [HttpGet()]
        [Route( nameof(TestCancell))]
        public async Task<IActionResult> TestCancell(CancellationToken token)
        {
            _logger.LogInformation("start Action");
            await Task.Delay(10_000, token);
            _logger.LogInformation("finish Action");
            return Ok(0);
        }
        [Produces("application/json")]
        [HttpGet()]
        [Route(nameof(TestWithoutCancell))]

        public async Task<IActionResult> TestWithoutCancell()
        {
            _logger.LogInformation("start Action");
            await Task.Delay(10_000);
            _logger.LogInformation("finish Action");
            return Ok(0);
        }


    }
}