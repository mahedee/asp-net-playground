namespace DemoApp.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        // The Invoke method is called by the ASP.NET Core runtime
        // for each HTTP request.
        public async Task Invoke(HttpContext context)
        {
            // Log request information
            _logger.LogInformation($"Request: {context.Request.Path}");

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}
