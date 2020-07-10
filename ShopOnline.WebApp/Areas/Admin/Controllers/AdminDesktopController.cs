using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Bll;
using ShopOnline.Dal;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.WebApp.Filter;

namespace ShopOnline.WebApp.Areas.Admin.Controllers
{
    [AdminAuthorize()]
    public class AdminDesktopController : Controller
    {
        // GET: Admin/AdminDesktop
        [HttpGet]
        public ActionResult Main()
        {
            AdminDto admin = (AdminDto)Session["Admin"];

            return View(admin);
        }
        [HttpPost]
        public async Task<ActionResult> GetCount()
        {

            IDictionary<string,int>dic=new Dictionary<string, int>();

            IStatisticsManager manager = new StatisticsManager();

            IUserManager manager2 = new UserManager(new UserService());

            IOrderInfoManager manager3=new OrderInfoManager(new OrderInfoService());

            var count =await manager.GetProductCount();

            var count2=await manager2.GetAllUser().CountAsync();
            var dateTime = DateTime.Now;

            var count3 = await manager3.QueryAllOrder(false).CountAsync();
            var count4 = manager3.QueryAllOrder(false)
                .Where(m => m.CreateTime.Month ==dateTime.Month)
                .Sum(m => m.TotalPrice);
           
            dic.Add("UserCount",count2);
            dic.Add("ProductCount", count);
            dic.Add("OrderCount", count3);
            dic.Add("BusinessMoney", Convert.ToInt32(count4));

            return Json(dic);
        }
    }
}