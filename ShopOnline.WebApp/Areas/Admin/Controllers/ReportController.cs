using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline.IBll;

namespace ShopOnline.WebApp.Areas.Admin.Controllers
{
    public class ReportController : Controller
    {
        private IOrderInfoManager _manager;

        public ReportController(IOrderInfoManager manager)
        {
            _manager = manager;
        }
        // GET: Admin/Report
        [HttpPost]
        public JsonResult Index()
        {
            var data = _manager.QueryAllOrder(false)
                .GroupBy(m => new {m.CreateTime.Month, m.TotalPrice})
                .Select(m => new
                {
                    month = m.Key.Month,
                    total = m.Sum(x=>x.TotalPrice)
                });
            List<string> nameList = new List<string>();
            List<int> countList = new List<int>();
            Dictionary<string, object> dic = new Dictionary<string, object>();

            foreach (var item in data)
            {
                nameList.Add(item.month+"月");
                countList.Add(Convert.ToInt32(item.total));
            }
            dic.Add("list1", nameList);
            dic.Add("list2", countList);
            return Json(dic);
        }
    }
}