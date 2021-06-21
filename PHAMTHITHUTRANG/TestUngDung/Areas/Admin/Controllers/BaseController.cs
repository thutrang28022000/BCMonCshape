
using ModelEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TestUngDung.Areas.Admin.Models;
//using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (LoginModel)Session[Constants.USER_SESSION];
            //var session = (LoginModel)Session[Constans.USER_SESSION];
            if (session== null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { Controller = "Login", action = "Index", Areas = "Admin" }));
            }
            base.OnActionExecuted(filterContext);

    }
    }
}