using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ShopOnline.Bll;
using ShopOnline.Dal;
using ShopOnline.Dto;
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

        public async Task<ActionResult> OrderInfo(string id)
        {
            var data =await _manager.QueryOrder(Guid.Parse(id));

            IOrderManager manager=new OrderManager(new OrderService());
            IDictionary<string,object> dic= new Dictionary<string, object>();
            IProductManager manager1=new ProductManager(new ProductService());
            var data2=manager.QueryAllOrder(data.Id);
            var distribution= _manager.QueryOrderDistribution(data.Id);
            List<ProductDto>list=new List<ProductDto>();

            foreach (var item in data2)
            {
                list.Add(await manager1.QueryProduct(item.ProductId));
            }

            dic.Add("OrderInfo",data);
            dic.Add("Distribution", distribution);
            dic.Add("ProductList", list);

            return View(dic);
        }
    }
}