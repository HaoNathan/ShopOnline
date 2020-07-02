using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Dto;

namespace ShopOnline.WebApp.Areas.Admin.Controllers
{
    public class AdminDesktopController : Controller
    {
        // GET: Admin/AdminDesktop
        public ActionResult Main()
        {
            AdminDto admin = (AdminDto)Session["Admin"];

            return View(admin);
        }
    }
}