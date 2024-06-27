using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Class08.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ExceptiionAttributeFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new RedirectResult("Error");
        }
    }
}
