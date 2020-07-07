using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline.WebApp.Filter;

namespace ShopOnline.WebApp.Controllers
{
    [UserAuthorize()]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        
    }
}