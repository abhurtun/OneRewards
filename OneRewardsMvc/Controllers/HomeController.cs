using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneRewardsMvc.Controllers
{
        [HandleError]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "OneRewards is yours one stop shop for collecting your rewards.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "OneRewards Administrator";

            return View();
        }
    }
}
