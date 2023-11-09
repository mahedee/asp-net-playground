using Microsoft.AspNetCore.Mvc.Filters;

namespace DemoApp.Filters
{
    public class LoggingActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // This method is called before the action method is executed
            // sample output will be like this:
    

            Console.WriteLine($"Action: {context.ActionDescriptor.DisplayName} started with arguments:" +
                $" {string.Join(", ", context.ActionDescriptor.Parameters)}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Action: {context.ActionDescriptor.DisplayName} completed with result: {context.Result}");
        }
    }
}
