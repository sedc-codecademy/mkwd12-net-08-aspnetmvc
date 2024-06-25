using Microsoft.AspNetCore.Mvc.Filters;

namespace Class08.Filters
{
    public class LogFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine ("Finished executing the given action");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Executing filter on executing the given action");
        }
    }
}
