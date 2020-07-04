using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.WebApp.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        [HttpGet]
        public ActionResult OrderList()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetOrderList()
        {
            return Json(null);
        }
    }
}