using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Dto;

namespace ShopOnline.WebApp.Areas.Admin.Controllers
{
    public class AdminMainBoardController : Controller
    {
        // GET: Admin/AdminMainBoard
        public ActionResult MainBoard()
        {
            AdminDto admin =(AdminDto) Session["Admin"];
            return View(admin);
        }
    }
}