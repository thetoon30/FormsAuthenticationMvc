using FormsAuthenticationMvc_Demo.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FormsAuthenticationMvc_Demo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error()
        {
            Exception exception = Server.GetLastError();
            //Log your exception here
            Response.Clear();
            // clear error on server
            Server.ClearError();

            Response.Redirect(String.Format("~/Error"));
        }
    }
}
