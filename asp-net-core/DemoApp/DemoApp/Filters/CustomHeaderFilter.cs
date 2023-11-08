using Microsoft.AspNetCore.Mvc.Filters;

namespace DemoApp.Filters
{
    public class CustomHeaderFilter : IActionFilter
    {
        private readonly string _headerName;
        private readonly string _headerValue;

        public CustomHeaderFilter(string headerName, string headerValue)
        {
            _headerName = headerName;
            _headerValue = headerValue;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // This method is called before the action method is executed
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // This method is called after the action method is executed
            context.HttpContext.Response.Headers.Add(_headerName, _headerValue);
        }
    }
}
