using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CancellationWithExceptionFilter
{
    public class CanellExceptionHandler:ExceptionFilterAttribute
    {
        private readonly ILogger _logger;
        public CanellExceptionHandler(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<CanellExceptionHandler>();
        }
        public override void OnException(ExceptionContext context)
        {

            if (context.Exception is OperationCanceledException)
            {
                _logger.LogInformation("Request Cancelled");
                context.ExceptionHandled = true;
                context.Result = new StatusCodeResult(499);
            }
        }
    }
}
