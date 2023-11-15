namespace DemoApp.Middleware
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // The Invoke method is called by the ASP.NET Core runtime
        // for each HTTP request.
        public async Task Invoke(HttpContext context)
        {
            // Perform some custom logic before passing the request to the next middleware
            context.Response.Headers.Add("X-MyHeader", "Hello from Middleware");

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}
