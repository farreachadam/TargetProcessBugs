using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using TargetProcessBugs.Core.MVC.Alerts;

namespace TargetProcessBugs.Core.MVC.Filters
{
    public abstract class AuthenticatedFilterBase : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            // check for AllowAnonymous attribute
            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), false).Any())
            {
                return;
            }

            // check if user is authenticated
            if(!IsAuthenticated())
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "Home" },
                        { "action", "Login" }
                    })
                    .WithError("Gotta be logged in to TargetProcess!");
            }

            OnActionExecuting(filterContext);

        }

        public abstract bool IsAuthenticated();
    }
}
