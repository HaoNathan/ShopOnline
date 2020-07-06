using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Bll;
using ShopOnline.Dto;
using ShopOnline.IBll;

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
        [HttpGet]
        public async Task<ActionResult> GetCount()
        {
            IStatisticsManager manager = new StatisticsManager();

            var count =await manager.GetProductCount();


            var jsonResult = new { productCount=count};
            return Json(jsonResult);
        }
    }
}