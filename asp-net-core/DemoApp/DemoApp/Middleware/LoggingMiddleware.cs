namespace DemoApp.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // The Invoke method is called by the ASP.NET Core runtime
        // for each HTTP request.
        public async Task Invoke(HttpContext context)
        {
            // Log the request to the console
            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

            // Call the next middleware in the pipeline
            await _next(context);

            // Log the response to the console
            Console.WriteLine($"Response: {context.Response.StatusCode}");
        }
    }
}
