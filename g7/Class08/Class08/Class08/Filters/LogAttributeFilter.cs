using Microsoft.AspNetCore.Mvc.Filters;

namespace Class08.Filters
{
    public class LogAttributeFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Attribute filter Finished executing given action");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("AttributeFilter Executing filter on executing given action");
        }
    }
}
