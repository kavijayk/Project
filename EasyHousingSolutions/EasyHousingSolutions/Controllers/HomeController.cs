using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyHousingSolutions.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Home()
        {
            if (Session["userType"] != null)
            {
                //    Session["userType"] = Session["userType"].ToString();
                //    Session["userName"] = Session["userName"].ToString();
            }
            return View();
        }
    }
}