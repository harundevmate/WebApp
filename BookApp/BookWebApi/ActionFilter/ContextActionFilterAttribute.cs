using Microsoft.AspNetCore.Mvc.Filters;

namespace BookWebApi.ActionFilter
{
    public class ContextActionFilterAttribute: ActionFilterAttribute,IActionFilter
    {
        public ContextActionFilterAttribute()
        {

        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}
