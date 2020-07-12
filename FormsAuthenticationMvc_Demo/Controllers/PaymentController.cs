using FormsAuthenticationMvc_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormsAuthenticationMvc_Demo.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            int t = Convert.ToInt32("5a55");

            return View();
        }
    }
}