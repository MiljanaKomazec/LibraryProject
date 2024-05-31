using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace ValconLibrary.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing the request");
                await HandleExceptionAsync(context);
            }
        }

        private Task HandleExceptionAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var errorMessage = "An error occurred while processing the request";
            var exception = context.Features.Get<IExceptionHandlerFeature>();
            if (exception != null)
            {
                errorMessage = exception.Error.Message;
            }

            var response = new
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = errorMessage
            };

            var jsonErrorResponse = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(jsonErrorResponse);
        }
    }
}
