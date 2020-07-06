using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ShopOnline.IBll;
using ShopOnline.WebApp.Common;
using ShopOnline.WebApp.Filter;

namespace ShopOnline.WebApp.Areas.Admin.Controllers
{
    [AdminAuthorize()]
    public class OrderController : Controller
    {
        private readonly IOrderInfoManager _manager;
        private MsgResult _msg;
        public OrderController(IOrderInfoManager manager)
        {
            _manager = manager;
        }
        // GET: Admin/Order
        [HttpGet]
        public ActionResult OrderList()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetOrderList(int page, int limit, string acceptName, string phone, string createTime)
        {
            var data = _manager.QueryAllOrder(true);

            if (!string.IsNullOrEmpty(acceptName)) data = data.Where(m => m.AcceptName .Contains(acceptName));

            if (!string.IsNullOrEmpty(phone))
            {
                data = data.Where(m => m.Phone.Equals(phone));
            }

            if (!string.IsNullOrEmpty(createTime))
            {
                var time = DateTime.Parse(createTime);
                data = data.Where(m => m.CreateTime > time);
            }

            var dataCount = data.Count();
            var newData = data.ToList().Skip((page - 1) * limit).Take(limit);


            var jsonResult = new
            {
                code = 0,
                count = dataCount,
                data = newData
            };

            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateOrderState(string id,bool state )
        {
            _msg=new MsgResult();
            var res = await _manager.UpdateOrderState(Guid.Parse(id),state);

            if (res==1)
            {
                _msg.IsSuccess = true;
                _msg.Info = "修改状态成功";
            }
            else
            {
                _msg.IsSuccess = true;
                _msg.Info = "修改状态成功";
            }

            return Json(_msg);
        }

    }
}